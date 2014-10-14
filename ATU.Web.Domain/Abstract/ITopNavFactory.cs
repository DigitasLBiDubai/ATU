
using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Abstract
{
    public interface ITopNavFactory
    {
        TopNav BuildTopNav(string portalTitle, string CurrentUserName);
    }
}