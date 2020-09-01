using JAKs24HourSocialMedia.Data;
using JAKs24HourSocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Services
{
    public class LikeService
    {
        private readonly int _id;
        private readonly int _postid;
        public LikeService(int userId, int postId)
        {
            _id = userId;
            _postid = postId;

        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                Like = model.Like,
                LikerId = _id,
                PostId = _postid
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItems> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .likes
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
