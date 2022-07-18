using API.Models;

namespace API.Repositories.Repositories
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
