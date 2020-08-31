using JAKs24HourSocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Models
{
    public class CommentCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Enter at least 1 character")]
        public string Text { get; set; }
    }
}
