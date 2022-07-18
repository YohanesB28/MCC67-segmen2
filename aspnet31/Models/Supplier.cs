using System.ComponentModel.DataAnnotations;

namespace aspnet31.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(25)]
        [MinLength(6, ErrorMessage = "Minimum Length is 6")]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
