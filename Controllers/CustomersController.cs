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

namespace ASPVidly.Controllers
{
    public class CustomersController : DbController
    {
        public ActionResult New()
        {
            return ViewFor<CustomerFormViewModel>("CustomerForm");
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
                _context.Customers.Add(customer); //..Create a new customer
            else
            {
                //..Since we're editing, get a copy of the customer we want to edit
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Mapper.Map(customer, customerInDb);
                // ^ Ordinarily, we'd create a custom DTO (Data Transfer object) and pass it to
                //       the automapper to update specfic properties rather than all of them.
                //

                //..update the properties
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            //..Save the changes
            _context.SaveChanges();

            //..Return to the original list of customers to see our changes/additions
            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);

            return View(customers);
        }

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

            return View("CustomerForm", viewModel);
        }
    }
}