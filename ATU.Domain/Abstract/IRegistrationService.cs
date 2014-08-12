using ATU.Domain.Model;

namespace ATU.Domain.Abstract
{
    public interface IRegistrationService
    {
        User CreateUser(User user, UserProfile userProfile, string password, string userRole);
        User CreateUserAndLogin(User user, UserProfile userProfile, string password, string userRole);
    }
}