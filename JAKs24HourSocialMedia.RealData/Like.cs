using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.RealData
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }//Bool?

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public User Liker { get; set; }//bool
    }
}
