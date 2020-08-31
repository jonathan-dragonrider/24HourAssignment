using JAKs24HourSocialMedia.Data;
using JAKs24HourSocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Services
{
    class CommentService
    {
        private readonly int _id;
        public CommentService(int userId)
        {
            _id = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                OwnerId = _id,
                Text = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
