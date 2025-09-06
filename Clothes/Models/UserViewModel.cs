using System.ComponentModel.DataAnnotations;

namespace Clothes.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "please enter your name")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "please enter your lastname")]
        [MaxLength(20, ErrorMessage = "lastname must be less than 20 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "please enter your Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter your password")]
        public string Password { get; set; }
    }
}
