﻿using aspnet31.Context;
using aspnet31.Models;
using aspnet31.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace aspnet31.Repositories.Data
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

        public Login get(string username, string password)
        {
            var data = myContext.UserRoles.Include(x => x.Users)
                                          .Include(x => x.Users.Employees)
                                          .Include(x => x.Roles)
                                          .Where(x => x.Users.Username == username)
                                          .Where(x => x.Users.Password == password)
                                          .ToList();
            Login login = new Login();
            login.Username = data.FirstOrDefault().Users.Employees.FullName;
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
