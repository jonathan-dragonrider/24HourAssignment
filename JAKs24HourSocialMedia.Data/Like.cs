using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Data
{
    class Like
    {
        public int PostId { get; set; }
        public Post LikedPost { get; set; }//Bool?
        public int LikerId { get; set; }
        public User Like { get; set; }
    }
}
