using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tetantrulz.Models;
using tetantrulz.viewmodel;
using System.Data.Entity;

namespace tetantrulz.Controllers
{
    public class MovieController : Controller
    {
        private MyDBContext _context;
        public MovieController()
        {
            _context = new MyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new movie() { name = "Singam" };
            var customers = new List<Customer> 
            {   new Customer {name="customer 1"},
                new Customer{name="customer 2" }, 
                new Customer{name="customer 3" }
            };
            var viewmodel = new RandomMovieViewModel() { 
                movie = movie, 
                Customer = customers
            };
            return View(viewmodel);
        }

        // Get: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private IEnumerable<movie> GetMovies()
        {
            return new List<movie>
            {
                new movie { Id = 1, name = "avatar" },
                new movie { Id = 2, name = "master" }
            };
        }
    }
}