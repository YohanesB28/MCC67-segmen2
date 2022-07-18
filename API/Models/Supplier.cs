using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [MinLength(6)]
        [MaxLength(28)]
        public string Name { get; set; }
    }
}
