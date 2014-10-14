
namespace ATU.Domain.Abstract
{
    public interface IAuthenticationService
    {
        bool Login(string userName, string password, bool rememberMe);
        void Logout();
        string CreateAccount(string userName, string password);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
        int GetUserId(string userName);
        string GetCurrentUserName();
    }
}