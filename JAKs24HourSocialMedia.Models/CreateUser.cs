using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAKs24HourSocialMedia.Models
{
    public class CreateUser
    {
        [Required]
        [MinLength(2, ErrorMessage = "Must Be at leat 2 Characters.")]
        [MaxLength(25, ErrorMessage = "Name must be under 25 characters.")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
