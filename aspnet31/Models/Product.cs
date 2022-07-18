using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet31.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(25)]
        [MinLength(6, ErrorMessage = "Minimum Length is 6")]
        [MaxLength(25)]
        public string name { get; set; }

        public virtual Supplier suppliers { get; set; }
        [ForeignKey("suppliers")]
        public int SupplierId { get; set; }
    }
}
