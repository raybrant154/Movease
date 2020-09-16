using Microsoft.AspNet.Identity;
using Movease.Models;
using Movease.Models.UserModel;
using Movease.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Movease.Controllers
{
    public class UserController : ApiController
    {
        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userId);
            return userService;
        }

        [HttpGet]
        [Route("api/Users")]
        public IHttpActionResult GetAllUsers()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("api/User/NewUser")]
        public IHttpActionResult PostUser(UserCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(user))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        [Route("api/User")]
        public IHttpActionResult GetUserById(int id)
        {
            UserService userService = CreateUserService();
            var user = userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPut]
        [Route("api/User/UpdateUser")]
        public IHttpActionResult UpdateUser(UserEdit user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        [Route("api/User/DeleteUser")]
        public IHttpActionResult DeleteUser(int id)
        {
            var service = CreateUserService();

            if (!service.DeleteUser(id))
                return InternalServerError();

            return Ok();
        }
    }
}
