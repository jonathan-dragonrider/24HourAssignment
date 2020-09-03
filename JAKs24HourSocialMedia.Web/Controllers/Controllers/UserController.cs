using JAKs24HourSocialMedia.Models;
using JAKs24HourSocialMedia.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JAKs24HourSocialMedia.WebAPI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private UserService CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userId);
            return userService;
        }

        public IHttpActionResult Get()
        {
            UserService userService = CreateUserService();
            var users = userService.GetUsers();
            return Ok(users);
        }
        public IHttpActionResult Post(CreateUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UserCreate(user))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            UserService userService = CreateUserService();
            var note = userService.GetUserById(id);
            return Ok(note);
        }

    }
}
