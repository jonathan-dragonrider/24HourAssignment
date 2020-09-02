using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.RealData
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public Guid OwnerId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual List<Post> Posts { get; set; } = new List<Post>();
        public virtual List<Like> Likes { get; set; } = new List<Like>();
    }
}
