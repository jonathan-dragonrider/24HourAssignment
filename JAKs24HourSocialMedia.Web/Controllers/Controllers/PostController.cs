using JAKs24HourSocialMedia.Models;
using JAKs24HourSocialMedia.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace JAKs24HourSocialMedia.WebAPI.Controllers
{
    public class PostController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var service = CreatePostService(id);
            var posts = service.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Post(PostCreate post, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService(id);

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
           
        }

        private PostService CreatePostService(int userId)
        {
            var postService = new PostService(userId);
            return postService;
        }
    }
}
