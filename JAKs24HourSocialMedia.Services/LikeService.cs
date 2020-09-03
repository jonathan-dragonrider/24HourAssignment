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
        private readonly int _id;
        public LikeService(int userId)
        {
            _id = userId;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                PostId = model.LikedPostId,
                UserId = _id
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}

