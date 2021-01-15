using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tetantrulz.Dtos;
using tetantrulz.Models;

namespace tetantrulz.Controllers.api
{
    public class MovieController : ApiController
    {
        private MyDBContext _context;

        public MovieController()
        {
            _context = new MyDBContext();
        }
        public IEnumerable<movieDTO> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<movie, movieDTO>);
        }
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<movie, movieDTO>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(movieDTO moviedto)
        {
            var newmovie = Mapper.Map<movieDTO, movie>(moviedto);
            _context.Movies.Add(newmovie);
            _context.SaveChanges();
            moviedto.Id = newmovie.Id;
            return Created(new Uri(Request.RequestUri + "/" + newmovie.Id), moviedto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, movieDTO moviedto)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<movieDTO, movie>(moviedto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieindb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieindb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Response.ContentType = " application/json";
            _context.Movies.Remove(movieindb);
            _context.SaveChanges();
            return Ok();
        }

    }
}
