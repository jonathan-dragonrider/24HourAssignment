using JAKs24HourSocialMedia.RealData;
using JAKs24HourSocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JAKs24HourSocialMedia.Services
{
    public class PostService
    {
        private readonly int _userId;

        public PostService(int id)
        {
            _userId = id;
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
                                    Title = e.Title,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                Title = model.Title,
                Text = model.Text,
                UserId = _userId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

    }
}
