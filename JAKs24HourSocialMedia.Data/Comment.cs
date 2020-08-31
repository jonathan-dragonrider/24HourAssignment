using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Data
{
    class Comment
    {
        [ForeignKey(nameof(Id))]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public User Author { get; set; }

        [Required]
        public Post CommentPost { get; set; }
    }
}
