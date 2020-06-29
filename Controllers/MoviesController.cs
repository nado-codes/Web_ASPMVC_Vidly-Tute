using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPTute_Vidly.Models;
using ASPVidly.Models;
using ASPVidly.ViewModels;

namespace ASPVidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        /*List<Movie> movies = new List<Movie>()
        {
            new Movie() {Id = 1, Name = "Shrek"},
            new Movie() {Id = 2, Name = "Wall-E"}
        };*/

        // GET: Movies
        /*public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek"};

            List<Customer> customers = new List<Customer>()
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
                new Customer {Name = "Customer 3"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }*/

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(c => c.Genre);

            return View();
        }

        [Route("movies/{id}")]
        public ActionResult GetMovie(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Movie movie = null;//_context.Movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
                return View("UnknownMovie");
            else
            {
                return View("MovieDetail", movie);
            }
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}:range(1,12))}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}