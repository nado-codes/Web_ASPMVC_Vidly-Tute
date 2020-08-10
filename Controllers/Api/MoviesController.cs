using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ASPTute_Vidly.Dtos;
using ASPVidly.Models;

namespace ASPTute_Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        // GET: /api/Movies
        [HttpGet]
        public IEnumerable<MovieDto> GetMovies()
        {
            return RepoController.Context.Movies.ToList().Select(c => VidlyMapper.Map<Movie, MovieDto>(c));
        }

        // Get /api/Movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var Movie = RepoController.Context.Movies.SingleOrDefault(c => c.Id == id);

            if (Movie == null)
                return NotFound();

            return Ok(VidlyMapper.Map<Movie, MovieDto>(Movie));
        }

        // POST /api/Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Movie Movie = VidlyMapper.Map<MovieDto, Movie>(MovieDto);

            RepoController.Context.Movies.Add(Movie);
            RepoController.Context.SaveChanges();

            MovieDto.Id = Movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + Movie.Id), MovieDto);
        }

        // PUT /api/Movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto MovieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Movie MovieInDb = RepoController.Context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            VidlyMapper.Map(MovieDto, MovieInDb);

            RepoController.Context.SaveChanges();

            return Ok(VidlyMapper.Map<Movie, MovieDto>(MovieInDb));
        }

        // DELETE api/Movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var MovieInDb = RepoController.Context.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            RepoController.Context.Movies.Remove(MovieInDb);
            RepoController.Context.SaveChanges();

            return Ok(VidlyMapper.Map<Movie, MovieDto>(MovieInDb));
        }
    }
}
