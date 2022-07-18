using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [MinLength(6)]
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual Supplier Suppliers { get; set; }
        [ForeignKey("Suppliers")]
        public int SupplierId { get; set; }
    }
}
