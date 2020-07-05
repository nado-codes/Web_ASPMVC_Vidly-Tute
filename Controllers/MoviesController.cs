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
using ASPTute_Vidly.Controllers;

namespace ASPVidly.Controllers
{
    public class MoviesController : DbController
    {
        public ActionResult New()
        {
            return ViewFor<MovieFormViewModel>("MovieForm");
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;

                _context.Movies.Add(movie); //..Create a new movie
            }
            else
            {
                //..Since we're editing, get a copy of the movie we want to edit
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                //Mapper.Map(customer, customerInDb);
                // ^ Ordinarily, we'd create a custom DTO (Data Transfer object) and pass it to
                //       the automapper to update specfic properties rather than all of them.
                //

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumInStock = movie.NumInStock;
            }

            //..Save the changes
            _context.SaveChanges();

            //..Return to the original list of movies to see our changes/additions
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre);

            return View(movies);
        }

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