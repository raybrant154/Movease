
﻿using Microsoft.AspNet.Identity;
using Movease.Data;
﻿using Microsoft.VisualBasic.Devices;
using Movease.Models.MoviesModel;
using Movease.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Movease.Controllers
{
    public class MovieController : ApiController
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            Task<HttpResponseMessage> getTask = httpClient.GetAsync("http://www.omdbapi.com/?apikey=223a36fc");

            HttpResponseMessage response = getTask.Result;

            HttpResponseMessage getResponse = httpClient.GetAsync("http://www.omdbapi.com/?apikey=223a36fc").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Mouse movieResponse = response.Content.ReadAsAsync<Movie>().Result;
            }
    { // google routing data asp .net
        private MovieService CreateMovieService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var movieService = new MovieService(userId);
            return movieService;
        }

        [HttpGet]
        [Route("api/Movie/{t}")]
        public IHttpActionResult GetMovieByTitleFromAPI(string t) //This Method gets a movie from the database
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

        public IHttpActionResult Post(MovieCreate movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMovieService();
            if (!service.CreateMovie(movie))
                return InternalServerError();

            return Ok();
        }


    }
}
