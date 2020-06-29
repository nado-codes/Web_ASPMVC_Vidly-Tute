using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPTute_Vidly.Models;
using ASPVidly.Models;
using ASPVidly.ViewModels;
using System.Data.Entity;

namespace ASPVidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);

            return View(customers);
        }

        [Route("customers/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Customer customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return View("UnknownCustomer");
            else
            {
                return View("CustomerDetail", customer);
            }
        }
    }
}