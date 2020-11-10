using System.ComponentModel.DataAnnotations;

namespace Pazar.Identity.Models
{
    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
