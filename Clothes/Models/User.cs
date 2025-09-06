using System.ComponentModel.DataAnnotations;

namespace Clothes.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public List<OrderItem> orderItems { get; set; }
    }
}
