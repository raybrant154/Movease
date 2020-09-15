using Microsoft.AspNet.Identity;
using Movease.Models.MovieListModel;
using Movease.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movease.Controllers
{
    public class MovieListController : ApiController
    {
        private MovieListService CreateMovieListService()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var movieListService = new MovieListService(userId);
            return movieListService;
        }


        public IHttpActionResult Get()
        {
            MovieListService movieListService = CreateMovieListService();
            var moviesList = movieListService.GetMovieList();
            return Ok(moviesList);
        }

        public IHttpActionResult Get(int id)
        {
            MovieListService movieListService = CreateMovieListService();
            var movieList = movieListService.GetMovieListById(id);
            return Ok(movieList);
        }

        public IHttpActionResult Post(ListCreate movieList)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMovieListService();
            if (!service.CreateMovieList(movieList))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ListEdit movieList)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMovieListService();

            if (!service.UpdateMovieOnList(movieList))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMovieListService();

            if (!service.DeleteMovieList(id))
                return InternalServerError();

            return Ok();
        }
    }
}
