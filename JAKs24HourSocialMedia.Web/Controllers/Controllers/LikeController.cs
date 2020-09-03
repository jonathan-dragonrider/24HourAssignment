using JAKs24HourSocialMedia.RealData;
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
    public class LikeController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        //CRUD

        [HttpPost]
        public async Task<IHttpActionResult> PostLike(Like model)
        {
            if(model == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.Likes.Add(model);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            Like like = await _context.Likes.FindAsync(id);
            if (like != null)
            {
                return Ok(like);
            }
            return NotFound();
        }

        // (GetAll) Read
        [HttpGet]
        public async Task<IHttpActionResult> GeAll()
        {
            List<Like> like = await _context.Likes.ToListAsync();
            return Ok(like);
        }

        // (Put) Update
        [HttpPut]
        public async Task<IHttpActionResult> UpdateComment([FromUri] int id, [FromBody] Like updatedLike)
        {
            if (ModelState.IsValid)
            {
                Like like = await _context.Likes.FindAsync(id);
                if (like != null)
                {
                    like.Id = updatedLike.Id;

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
            Like entity = await _context.Likes.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Likes.Remove(entity);

            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("Comment has been deleted");
            }

            return InternalServerError();
        }
    }
}
