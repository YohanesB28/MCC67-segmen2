using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Role Name")]
        public string Name { get; set; }
    }
}
