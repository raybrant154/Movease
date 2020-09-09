using Movease.Data;
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
    { // google routing data asp .net
        public IHttpActionResult Get (string t) //This Method gets a movie from the database
        {
            MovieService movieService = new MovieService();
            Movie movieResponse = movieService.GetMovieFromAPIAsync(t).Result;
            if (movieResponse != null) 
            {           //At this point, we should have our movie, we now need to add it to the database
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                //Movie movieResponse = response.Content.ReadAsAsync<Movie>().Result;

                return Ok(movieResponse);
            }

            return BadRequest(ModelState);
        }

        public IHttpActionResult Post(MovieCreate movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            return Ok();
        }
    }
}
