using Microsoft.AspNet.Identity;
using Movease.Models;
using Movease.Models.MyMovieCollectionModel;
using Movease.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movease.Controllers
{
    [Authorize]
    public class MyMovieCollectionController : ApiController
    {
        private MyMovieCollectionService CreateMyMovieCollectionService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var myMovieCollectionService = new MyMovieCollectionService(ownerId);
            return myMovieCollectionService;
        }

        [HttpGet]
        [Route("api/MyMovieCollection")]
        public IHttpActionResult Get()
        {
            MyMovieCollectionService myMovieCollectionService = CreateMyMovieCollectionService();
            var MyMovieCollections = myMovieCollectionService.GetMyMovieCollections();
            return Ok(MyMovieCollections);
        }

        [HttpPost]
        [Route("api/MyMovieCollection/NewMyMovieCollection")]
        public IHttpActionResult Post(MyMovieCollectionCreate myMovieCollection)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMyMovieCollectionService();

            if (!service.CreateMovieCollection(myMovieCollection))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        [Route("api/MyMovieCollection/UpdateMyMovieCollection")]
        public IHttpActionResult Put(MyMovieCollectionEdit myMovieCollection)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMyMovieCollectionService();

            if (!service.UpdateMyMovieCollection(myMovieCollection))
                return InternalServerError();

            return Ok();

        }

        [HttpDelete]
        [Route("api/MyMovieCollection/DeleteMyMovieCollection")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMyMovieCollectionService();

            if (!service.DeleteMyMovieCollection(id))
                return InternalServerError();

            return Ok();
        }
    }
}
