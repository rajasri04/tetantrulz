using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tetantrulz.Models;
using System.Data.Entity;
using tetantrulz.NewCustmerViewModel;

namespace tetantrulz.Controllers
{
    public class CustomerController : Controller
    {
        private MyDBContext _context;
        public CustomerController()
        {
            _context = new MyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.demo).ToList();

            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.demo).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
        public ActionResult New()
        {
            var membership = _context.demos.ToList();
            var viewmodel = new NewCustomerViewModel
            {
                demo = membership
            };
            return View("CustomerForm", viewmodel);
        }
        [HttpPost]
        [Route("api/controller")]
        public ActionResult Save(Customer customer)
        {

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.name = customer.name;
                customerInDb.issubcribed = customer.issubcribed;
                customerInDb.demoId = customer.demoId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult ApiNew()
        {
            var membership = _context.demos.ToList();
            var viewmodel = new NewCustomerViewModel
            {
                demo = membership
            };
            return View(viewmodel);
        }

        public ActionResult ApiPost()
        {
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewmodel = new NewCustomerViewModel
            {
                Customer = customer,
                demo = _context.demos.ToList()
            };
            return View("CustomerForm",viewmodel);
        }
        private IEnumerable<Customer> GetCustomers() {
            return new List<Customer>
            {
                new Customer { Id = 1, name = "John Smith" },
                new Customer { Id = 2, name = "Mary Williams" }
            };
        }
    }
}