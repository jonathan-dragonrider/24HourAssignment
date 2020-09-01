using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Data
{
    public class Like
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public Post LikedPost { get; set; }//Bool?

        [Required]
        public int LikerId { get; set; }

        [Required]
        public User Like { get; set; }//bool
    }
}
