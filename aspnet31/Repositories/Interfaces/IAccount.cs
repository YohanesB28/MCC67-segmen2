using aspnet31.Models;

namespace aspnet31.Repositories.Interfaces
{
    public interface IAccount
    {
        public void Login();
        public void Logout();
        public void ForgotPassword();
        public void ChangePassword();
        public int Register(Employee employees, User users);
    }
}
