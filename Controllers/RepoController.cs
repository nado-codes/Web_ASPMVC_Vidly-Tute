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
    public sealed class RepoController : Controller
    {
        private static RepoController _singleton;

        public static ApplicationDbContext Context { get; private set; }

        private RepoController(){}

        public static void Init()
        {
            Context = new ApplicationDbContext();
            _singleton = new RepoController();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        /// <summary>
        /// Create and map a view model with a database query, and return the resulting view
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="viewName"></param>
        /// <returns></returns>
        public static ActionResult ViewFor<V>(string viewName, V viewModel = default(V)) where V : new()
        {
            V newViewModel = (viewModel == null) ? VidlyMapper.Map(Context, new V()) : viewModel;

            return _singleton.View(viewName, newViewModel);
        }
    }
}