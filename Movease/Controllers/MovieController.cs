
﻿using Microsoft.AspNet.Identity;
using Movease.Data;
﻿using Microsoft.VisualBasic.Devices;

using Movease.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Movease.Models.MoviesModel;

namespace Movease.Controllers
{
    public class MovieController : ApiController
    { // google routing data asp .net
        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var movieService = new MovieService(userId);
            return movieService;
        }

        [HttpGet]
        [Route("api/Movie/{t}")]
        public IHttpActionResult GetMovieByTitleFromAPI(string t)
        {
            MovieService movieService = new MovieService();
            MovieDetail movieResponse = movieService.GetMovieFromAPIAsync(t).Result;
            if (movieResponse != null)
            {

                //Movie movieResponse = response.Content.ReadAsAsync<Movie>().Result;

                return Ok(movieResponse);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("api/Movie")]
        public IHttpActionResult GetMoviesFromDB()
        {
            MovieService movieService = CreateMovieService();
            var movies = movieService.GetMoviesFromDB();
            return Ok(movies);
        }

        public IHttpActionResult GetMoviesFromDBById(int id)
        {
            MovieService movieService = CreateMovieService();
            var movie = movieService.GetMovieFromDBById(id);
            return Ok(movie);
        }

        public IHttpActionResult Post(MovieCreate movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMovieService();
            if (!service.CreateMovie(movie))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(MovieEdit movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMovieService();

            if (!service.UpdateMovie(movie))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMovieService();

            if (!service.DeleteMovie(id))
                return InternalServerError();

            return Ok();
        }
    }
}
