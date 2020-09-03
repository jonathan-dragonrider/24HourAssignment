using JAKs24HourSocialMedia.RealData;
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
        private readonly Guid _id;
        private readonly int _postid;
        public LikeService(Guid userId, int postId)
        {
            _id = userId;
            _postid = postId;

        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                PostId = _postid,
                Id = _id
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}

