using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tetantrulz.Dtos;
using tetantrulz.Models;

namespace tetantrulz.Controllers.api
{
    public class CustomerController : ApiController
    {
        private MyDBContext _context;
        public CustomerController() 
        {
            _context = new MyDBContext();
            //WebResponse.ContentType = "application/json";
        }
        // Get/customer
        public IEnumerable<CustomerDTO> GetCustomer() 
        {
            return _context.Customers.Include(c=>c.demo).ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        //get/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }
        //post/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerdto)
        {
            var customer = Mapper.Map<CustomerDTO, Customer>(customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerdto);
        }

        //put/customer/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDTO customerdto) 
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<CustomerDTO, Customer>(customerdto, customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        //Delete/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id) {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Response.ContentType = " application/json";
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
