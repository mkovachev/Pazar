using Pazar.Core.Services.Data;
using System.ComponentModel.DataAnnotations;

namespace Pazar.Identity.Models
{
    using static DataConstants.Identity;
    public class UserIm
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
