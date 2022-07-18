using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class User
    {
        public virtual Employee Employees { get; set; }
        [Key]
        [ForeignKey("Employees")]
        public int Id { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Minimum Length of Username is 6 characters")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required.")]
        [MinLength(6, ErrorMessage = "Minimum Length of Password is 6 characters")]
        [MaxLength(18)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
