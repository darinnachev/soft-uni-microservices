using System.ComponentModel.DataAnnotations;

namespace Homebook.Identity.Models.Identity
{
    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
