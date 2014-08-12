using System;
using System.Linq;
using System.Web.Security;
using WebMatrix.WebData;
using ATU.Domain.Data.Repository.Abstract;
using ATU.Domain.Abstract;
using ATU.Domain.Model;

namespace ATU.Domain.Concrete
{
    public class RegistrationService : BaseService, IRegistrationService
    {
        public RegistrationService(IRepository repo) : base(repo) { }

        public User CreateUserAndLogin(User user, UserProfile userProfile, string password, string userRole)
        {
            WebSecurity.CreateUserAndAccount(user.UserName, password);
            WebSecurity.Login(user.UserName, password);

            var newUser = Repo.Find<User>(u => string.Equals(u.UserName, user.UserName)).Single();

            if (null == newUser)
                throw new InvalidOperationException("User must exist at this point");

            userProfile.DateCreatedUtc = DateTime.UtcNow;
            userProfile.LastModifiedUtc = DateTime.UtcNow;

            Repo.Add(userProfile);
            newUser.UserProfile = userProfile;
            Repo.SaveChanges();

            Roles.AddUserToRole(newUser.UserName, userRole);

            return newUser;
        }

        public User CreateUser(User user, UserProfile userProfile, string password, string userRole)
        {
            WebSecurity.CreateUserAndAccount(user.UserName, password);
            var newUser = Repo.Find<User>(u => string.Equals(u.UserName, user.UserName)).Single();

            if (null == newUser)
                throw new InvalidOperationException("User must exist at this point");

            Repo.Add(userProfile);
            newUser.UserProfile = userProfile;
            Repo.SaveChanges();

            Roles.AddUserToRole(newUser.UserName, userRole);

            return newUser;
        }

        public User UpdateUser(User user, string userRole)
        {
            var existingUser = Repo.Find<User>(u => string.Equals(u.UserName, user.UserName)).Single();

            if (null == existingUser)
                throw new InvalidOperationException("User must exist at this point");

            existingUser.UserProfile.FirstName = user.UserProfile.FirstName;
            existingUser.UserProfile.LastName = user.UserProfile.LastName;
            existingUser.UserProfile.Email = user.UserProfile.Email;
            existingUser.UserProfile.LastModifiedUtc = DateTime.UtcNow;

            Repo.SaveChanges();

            if (!Roles.IsUserInRole(user.UserName, userRole))
                Roles.AddUserToRole(user.UserName, userRole);

            return user;
        }
    }
}