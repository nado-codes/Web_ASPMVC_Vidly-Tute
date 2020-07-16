using ASPTute_Vidly.Models;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPVidly.Models;
using AutoMapper;
using ASPTute_Vidly.ViewModels;

namespace ASPTute_Vidly.Controllers
{
    public class DbController : Controller
    {
        protected ApplicationDbContext _context;

        public DbController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Create and map a view model with a database query, and return the resulting view
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="viewName"></param>
        /// <returns></returns>
        protected ActionResult ViewFor<V>(string viewName, V viewModel = default(V)) where V : new()
        {
            V newViewModel = (viewModel == null) ? VidlyMapper.Map(_context, new V()) : viewModel;

            return View(viewName, newViewModel);
        }
    }
}