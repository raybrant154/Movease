using Movease.Data;
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

        public IHttpActionResult Get(string t)
        {
            MovieService movieService = new MovieService();
            Movie movieResponse = movieService.GetMovieAsync(t).Result;
            if (movieResponse != null)
            {
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                //Movie movieResponse = response.Content.ReadAsAsync<Movie>().Result;

                return Ok(movieResponse);
            }

            return BadRequest(ModelState);
        }


    }
}
