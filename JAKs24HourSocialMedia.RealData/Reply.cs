using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.RealData
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        public string Text { get; set; }


        [ForeignKey(nameof(ReplyComment))]
        public int CommentId { get; set; }
        public Comment ReplyComment { get; set; }


        [ForeignKey(nameof(Author))]
        public int UserId { get; set; }
        public virtual User Author { get; set; }

    }
}
