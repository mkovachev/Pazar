using System.ComponentModel.DataAnnotations;

namespace Pazar.Identity.Models
{
    using static Data.DataConstants.Identity;

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
