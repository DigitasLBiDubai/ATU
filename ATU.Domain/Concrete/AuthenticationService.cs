using ATU.Domain.Abstract;
using ATU.Domain.Data.Repository.Abstract;
using WebMatrix.WebData;

namespace ATU.Domain.Concrete
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService(IRepository repo, IUserService userService) : base(repo)
        {
            _userService = userService;
        }

        public bool Login(string userName, string password, bool rememberMe)
        {
            var userProfile = _userService.GetUserProfile(userName);

            if (null == userProfile) return false;

            // if (userProfile.Status == 0 || userProfile.Status == -1) return false;

            return WebSecurity.Login(userName, password, persistCookie: rememberMe);
        }

        public void Logout()
        {
            WebSecurity.Logout();
        }

        public string CreateAccount(string userName, string password)
        {
            return WebSecurity.CreateAccount(userName, password);
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return WebSecurity.ChangePassword(userName, oldPassword, newPassword);
        }

        public int GetUserId(string userName)
        {
            return WebSecurity.GetUserId(userName);
        }

        public string GetCurrentUserName()
        {
            return WebSecurity.CurrentUserName;
        }
    }
}