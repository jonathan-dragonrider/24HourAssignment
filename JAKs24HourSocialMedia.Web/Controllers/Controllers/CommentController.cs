using JAKs24HourSocialMedia.Models;
using JAKs24HourSocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JAKs24HourSocialMedia.Web.Controllers.Controllers
{
    public class CommentController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var service = CreatePostService(id);
            var posts = service.GetComments();
            return Ok(posts);
        }
        public IHttpActionResult Post(CommentCreate post, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService(id);

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();

        }

        private CommentService CreatePostService(int userId)
        {
            var commentService = new CommentService(userId);
            return commentService;
        }
    }
}
