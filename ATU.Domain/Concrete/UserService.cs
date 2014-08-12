using ATU.Domain.Abstract;
using ATU.Domain.Data.Repository.Abstract;
using ATU.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace ATU.Domain.Concrete
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IRepository repo) : base(repo) { }

        public User GetUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("Please provide a username for this method.");

            return Repo.Find<User>(x => x.UserName == userName).Single();
        }

        public User GetUser(int userId)
        {
            return Repo.Find<User>(x => x.UserId == userId).Single();
        }

        public UserProfile GetUserProfile(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("Please provide a username for this method.");

            var users = Repo.Find<User>(x => x.UserName == userName);

            if (null == users || !users.Any()) return null;

            var user = users.FirstOrDefault();

            return user != null ? user.UserProfile : null;
        }

        public int GetNextUsernameNumber(string usernameInitials) 
        {
            var users = Repo.Find<User>(x => x.UserName.StartsWith(usernameInitials));
            var user = users.OrderByDescending(x => x.UserName).FirstOrDefault();

            if (null != user && Regex.Match(user.UserName, @"\d+").Success) 
            {
                return Convert.ToInt32(user.UserName.Substring(2, user.UserName.Length - 2)) + 1;
            }

            return 0;
        }

        public IEnumerable<User> GetUsersOfStatus(int status)
        {
            return Repo.Find<User>(x => x.UserProfile.Status == status);
        }

        public IEnumerable<User> GetUsersOfRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName)) return null;

            var allRoles = Roles.GetAllRoles();

            if (!allRoles.Contains(roleName)) return null;

            var users = Repo.Find<User>(x => x.UserProfile.Status == 1).ToList();
            return from ab in users where Roles.GetRolesForUser(ab.UserName).Contains(roleName) select ab;
        }

        public void UpdateUser(User user)
        {
            user.UserProfile.LastModifiedUtc = DateTime.UtcNow;
            Repo.SaveChanges();
        }
    }
}