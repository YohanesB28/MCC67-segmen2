using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public void Login(User user)
        {
            var roles = myContext.Roles.ToList();
            var employees = myContext.Employees.Where(x => x.Id == user.Id).SingleOrDefault();
        }

        public Login Get(string username, string password)
        {
            var data = myContext.UserRoles.Include(x => x.Users)
                                          .Include(x => x.Users.Employees)
                                          .Include(x => x.Roles)
                                          .Where(x => x.Users.Username == username)
                                          .Where(x => x.Users.Password == password)
                                          .ToList();
            Login login = new Login();
            login.UserName = data.FirstOrDefault().Users.Employees.FullName;
            login.Id = data.FirstOrDefault().Users.Id;
            foreach (var item in data)
            {
                login.Roles.Add(item.Roles);
            }
            return login;
        }

        public void Logout()
        {

        }

        public void ForgotPassword()
        {

        }

        public void ChangePassword()
        {

        }

        public int Register(Employee employee, User user)
        {
            myContext.Employees.Add(employee);
            var result = myContext.SaveChanges();
            myContext.Users.Add(user);
            result += myContext.SaveChanges();
            return result;
        }
    }
}
