using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Abstract
{
    public interface ILeftNavFactory
    {
        LeftNav BuildLeftNav(string selectedItemName, string[] userRoles);
    }
}