using JAKs24HourSocialMedia.Models;
using JAKs24HourSocialMedia.RealData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Services
{
    public class CommentService
    {
        private readonly int _userId;

        public CommentService(int id)
        {
            _userId = id;
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    Text = e.Text,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool CreatePost(CommentCreate model)
        {
            var entity = new Comment()
            {
               Text = model.Text,
               PostId = model.PostId,
               UserId = _userId,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
