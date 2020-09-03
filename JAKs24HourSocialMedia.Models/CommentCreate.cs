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
        public int PostId { get; set; }

        [Required]
        [MaxLength(8000, ErrorMessage = "Max length 8000 characters.")]
        public string Text { get; set; }
    }
}
