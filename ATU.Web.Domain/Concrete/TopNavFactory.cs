using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Concrete
{
    public class TopNavFactory : ITopNavFactory
    {
        public TopNav BuildTopNav(string portalTitle)
        {
            return new TopNav()
            {
                PortalTitle = portalTitle,
                LogOffUrl = string.Empty,
                ProfileUrl = string.Empty,
                SettingsUrl = string.Empty
            };
        }
    }
}