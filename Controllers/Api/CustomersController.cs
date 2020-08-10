using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ASPTute_Vidly.Dtos;
using ASPVidly.Models;

namespace ASPTute_Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        // GET: /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return RepoController.Context.Customers.ToList().Select(c => VidlyMapper.Map<Customer,CustomerDto>(c));
        }

        // Get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = RepoController.Context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(VidlyMapper.Map<Customer,CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Customer customer = VidlyMapper.Map<CustomerDto,Customer>(customerDto);

            RepoController.Context.Customers.Add(customer);
            RepoController.Context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri+"/"+customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Customer customerInDb = RepoController.Context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            VidlyMapper.Map(customerDto, customerInDb);

            RepoController.Context.SaveChanges();
        }

        // DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = RepoController.Context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            RepoController.Context.Customers.Remove(customerInDb);
        }
    }
}