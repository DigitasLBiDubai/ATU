using System.Collections.Generic;
using ATU.Domain.Model;

namespace ATU.Domain.Abstract
{
    public interface IUserService
    {
        User GetUser(string userName);
        User GetUser(int userId);
        void UpdateUser(User user);
        UserProfile GetUserProfile(string userName);
        IEnumerable<User> GetUsersOfStatus(int status);
        IEnumerable<User> GetUsersOfRole(string roleName);
        int GetNextUsernameNumber(string usernameInitials);
    }
}