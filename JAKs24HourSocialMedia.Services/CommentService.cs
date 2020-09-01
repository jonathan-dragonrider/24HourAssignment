using JAKs24HourSocialMedia.RealData;
using JAKs24HourSocialMedia.Models;
using System.Collections.Generic;
using System.Linq;

namespace JAKs24HourSocialMedia.Services
{
    public class CommentService
    {
        private readonly int _id;
        private readonly int _postid;
        public CommentService(int userId, int postId)
        {
            _id = userId;
            _postid = postId;

        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                Text = model.Text,
                Author = _id,
                CommentPost = _postid
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItems> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.Id == _id)
                        .Select(
                            e =>
                                new CommentListItems
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    Author = e.Author,
                                    CommentPost = e.CommentPost
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
