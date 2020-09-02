using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.RealData
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        [Required]
        [ForeignKey("User")]
        public int Id { get; set; }
        public virtual User User { get; set; }

        public virtual List<Like> Likes { get; set; } = new List<Like>();
    }
}
