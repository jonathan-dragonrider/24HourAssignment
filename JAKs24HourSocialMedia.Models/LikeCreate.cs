using JAKs24HourSocialMedia.RealData;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Models
{
    public class LikeCreate
    {
        [Required]
        public int LikedPostId { get; set; }

        [Required]
        public int LikerId { get; set; }
    }
}
