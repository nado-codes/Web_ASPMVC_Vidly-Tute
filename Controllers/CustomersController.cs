using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPTute_Vidly.Models;
using ASPVidly.Models;
using ASPVidly.ViewModels;
using System.Data.Entity;
using ASPTute_Vidly.ViewModels;
using AutoMapper;
using ASPTute_Vidly.Controllers;
using ASPTute_Vidly;

namespace ASPVidly.Controllers
{
    public class CustomersController : DbController
    {
        private readonly string CUSTOMER_FORM = "CustomerForm";
        private readonly string CUSTOMER_DETAIL = "CustomerDetail";
        private readonly string CUSTOMERS = "Customers";
        private readonly string UNKNOWN_CUSTOMER = "UnknownCustomer";
        private readonly string INDEX = "Index";
        
        public ActionResult New()
        {
            return ViewFor<CustomerFormViewModel>(CUSTOMER_FORM);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View(CUSTOMER_FORM, viewModel);
            }

            if(customer.Id == 0)
                _context.Customers.Add(customer); //..Create a new customer
            else
            {
                //..Since we're editing, get a copy of the customer we want to edit
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                VidlyMapper.Map(customer, customerInDb);
            }

            //..Save the changes
            _context.SaveChanges();

            //..Return to the original list of customers to see our changes/additions
            return RedirectToAction(INDEX, CUSTOMERS);
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction(INDEX);

            Customer customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return View(UNKNOWN_CUSTOMER);
            else
            {
                return View(CUSTOMER_DETAIL, customer);
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View(CUSTOMER_FORM, viewModel);
        }
    }
}