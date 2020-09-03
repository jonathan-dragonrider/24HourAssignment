using JAKs24HourSocialMedia.Models;
using JAKs24HourSocialMedia.RealData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Services
{
    public class ReplyService
    {
        private readonly int _userId;

        public ReplyService(int id)
        {
            _userId = id;
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyId = e.ReplyId,
                                    Text = e.Text,
                                }
                        );

                return query.ToArray();
            }
        }
        public bool CreatePost(ReplyCreate model)
        {
            var entity = new Reply()
            {
                Text = model.Text,
                CommentId = model.CommentId,
                UserId = _userId,

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
