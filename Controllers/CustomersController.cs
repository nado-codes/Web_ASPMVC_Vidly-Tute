using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPTute_Vidly.Models;
using ASPVidly.Models;
using ASPTute_Vidly.ViewModels;
using System.Data.Entity;
using System.Web.WebSockets;
using ASPTute_Vidly.ViewModels;
using AutoMapper;
using ASPTute_Vidly.Controllers;
using ASPTute_Vidly;

namespace ASPVidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly string CUSTOMER_FORM = "CustomerForm";
        private readonly string CUSTOMER_DETAIL = "CustomerDetail";
        private readonly string CUSTOMERS = "Customers";
        private readonly string UNKNOWN_CUSTOMER = "UnknownCustomer";
        private readonly string INDEX = "Index";
        
        public ActionResult New()
        {
            return RepoController.ViewFor<CustomerFormViewModel>(CUSTOMER_FORM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = RepoController.Context.MembershipTypes.ToList()
                };

                VidlyMapper.Map(customer, viewModel);

                return View(CUSTOMER_FORM, viewModel);
            }

            if(customer.Id == 0)
                RepoController.Context.Customers.Add(customer); //..Create a new customer
            else
            {
                //..Since we're editing, get a copy of the customer we want to edit
                var customerInDb = RepoController.Context.Customers.Single(c => c.Id == customer.Id);
                VidlyMapper.Map(customer, customerInDb);
            }

            //..Save the changes
            RepoController.Context.SaveChanges();

            //..Return to the original list of customers to see our changes/additions
            return RedirectToAction(INDEX, CUSTOMERS);
        }

        public ViewResult Index()
        {
            var customers = RepoController.Context.Customers.Include(c => c.MembershipType);

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction(INDEX);

            Customer customer = RepoController.Context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return View(UNKNOWN_CUSTOMER);
            else
            {
                return View(CUSTOMER_DETAIL, customer);
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = RepoController.Context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = RepoController.Context.MembershipTypes.ToList()
            };

            VidlyMapper.Map(customer, viewModel);

            return View(CUSTOMER_FORM, viewModel);
        }
    }
}