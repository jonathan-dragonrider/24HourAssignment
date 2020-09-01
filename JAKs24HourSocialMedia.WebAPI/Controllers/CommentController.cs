using JAKs24HourSocialMedia.Data;
using JAKs24HourSocialMedia.Models;
using JAKs24HourSocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace JAKs24HourSocialMedia.WebAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        //CRUD (PGPD)
        //Post
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
        private CommentService CreateCommentService()
        {
            var postId = int.Parse(Post.Id.GetPostId());
            var userId = int.Parse(User.Id.GetUserId());
            var commentService = new CommentService(userId, postId);
            return commentService;
        }

        public IHttpActionResult GetAll()
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetComments();
            return Ok(comment);
        }

        public IHttpActionResult GetById(int id)
        {
            Comment comment = Comment.Find(id);
        }

        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == id && e.userId == _userId);
                return
                    new CommentDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        Author = entity.Author,
                        CommentPost = entity.CommentPost
                    };
            }
        }
    }
}
