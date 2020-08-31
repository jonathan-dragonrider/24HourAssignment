using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Models
{
    public class CreatePost
    {
        [Required]
        [MinLength(1, ErrorMessage = "Must have at least one character.")]
        [MaxLength(100, ErrorMessage = "Max length 100 characters.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(8000, ErrorMessage = "Max length 8000 characters.")]
        public string Post { get; set; }
    }
}
