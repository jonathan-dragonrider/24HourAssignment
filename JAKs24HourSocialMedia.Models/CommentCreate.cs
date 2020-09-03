using System.ComponentModel.DataAnnotations;

namespace JAKs24HourSocialMedia.Models
{
    public class CommentCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Enter at least 1 character")]
        public string Text { get; set; }
    }
}
