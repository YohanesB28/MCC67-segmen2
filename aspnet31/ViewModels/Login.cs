using aspnet31.Models;
using System.Collections.Generic;

namespace aspnet31.ViewModels
{
    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Role> Roles = new List<Role>();
        //public IEnumerable<Role> Roles { get; set; }

        
    }
}
