using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public virtual User Users { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual Role Roles { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
    }
}
