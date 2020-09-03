using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.RealData
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Text { get; set; }

        [ForeignKey(nameof(Author))]
        public int UserId { get; set; }
        public virtual User Author { get; set; }

        [ForeignKey(nameof(CommentPost))]
        public int PostId { get; set; }
        public virtual Post CommentPost { get; set; }

        public virtual List<Reply> Replies { get; set; } = new List<Reply>();

    }
}
