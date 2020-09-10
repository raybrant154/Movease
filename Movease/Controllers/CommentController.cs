using Microsoft.AspNet.Identity;
using Movease.Models;
using Movease.Models.CommentModel;
using Movease.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movease.Controllers
{
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var CommentService = new CommentService(userId);
            return CommentService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var users = commentService.GetComments();
            return Ok(users);
        }

        [HttpPost]
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            CommentService CommentService = CreateCommentService();
            var user = CommentService.GetCommentById(id);
            return Ok(user);
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id))
                return InternalServerError();

            return Ok();
        }
    }
}
