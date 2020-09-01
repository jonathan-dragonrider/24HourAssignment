using JAKs24HourSocialMedia.RealData;
using JAKs24HourSocialMedia.Models;
using JAKs24HourSocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        /*public IHttpActionResult Post(CommentCreate comment)
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

        public IHttpActionResult GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == id && e.Id == _userId);
                return
                    new CommentDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        Author = entity.Author,
                        CommentPost = entity.CommentPost
                    };
            }
        }*/
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        // CRUD (PGPD)

        // (Post) Create
        [HttpPost]
        public async Task<IHttpActionResult> PostComment(Comment model)
        {
            if (model == null)
            {
                return BadRequest("Your request cannot be empty");
            }
            if (ModelState.IsValid)
            {
                _context.Comments.Add(model);
                await _context.SaveChangesAsync();
                return Ok("You've created a new Customer");
            }
            return BadRequest(ModelState);
        }

        // (GetbyId) Read
        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Comment comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound();
        }

        // (GetAll) Read
        [HttpGet]
        public async Task<IHttpActionResult> GeAll()
        {
            List<Comment> comment = await _context.Comments.ToListAsync();
            return Ok(comment);
        }

        // (Put) Update
        [HttpPut]
        public async Task<IHttpActionResult> UpdateComment([FromUri] int id, [FromBody] Comment updatedComment)
        {
            if (ModelState.IsValid)
            {
                Comment comment = await _context.Comments.FindAsync(id);
                if (comment != null)
                {
                    comment.Text = updatedComment.Text;

                    await _context.SaveChangesAsync();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        // (Delete) Delete
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteComment(int id)
        {
            Comment entity = await _context.Comments.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(entity);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("Comment has been deleted");
            }

            return InternalServerError();
        }
    }
}
