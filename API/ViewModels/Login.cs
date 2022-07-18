using API.Models;
using System.Collections.Generic;

namespace API.ViewModels
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Role> Roles = new List<Role>();
    }
}
