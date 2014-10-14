namespace ATU.Domain.Abstract
{
    public interface IClientAuthenticationService
    {
        string CreateAccount(string displayName);
        string Login(string username, string password);
    }
}