﻿using JAKs24HourSocialMedia.Models;
using JAKs24HourSocialMedia.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace JAKs24HourSocialMedia.WebAPI.Controllers
{
    public class PostController : ApiController
    {
        public IHttpActionResult Get()
        {
            var service = CreatePostService();
            var posts = service.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
           
        }

        private PostService CreatePostService()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
    }
}
