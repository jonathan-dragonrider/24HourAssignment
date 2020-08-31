using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Models
{
    public class CommentListItems
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int Author { get; set; }

        public int CommentPost { get; set; }
    }
}
