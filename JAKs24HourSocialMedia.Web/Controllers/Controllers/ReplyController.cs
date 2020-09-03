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
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var service = CreatePostService(id);
            var posts = service.GetReplies();
            return Ok(posts);
        }
        public IHttpActionResult Post(ReplyCreate post, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService(id);

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();

        }

        private ReplyService CreatePostService(int userId)
        {
            var replyService = new ReplyService(userId);
            return replyService;
        }
    }
}
