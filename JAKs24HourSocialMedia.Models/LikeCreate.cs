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
        public Post likedPost { get; set; }

        [Required]
        public User Like { get; set; }
    }
}
