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
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

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

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre);

            return View(movies);
        }

        [Route("movies/{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Movie movie = _context.Movies.Include(c => c.Genre).FirstOrDefault(m => m.Id == id);

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