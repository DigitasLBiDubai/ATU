using System.Linq;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Concrete
{
    public class LeftNavFactory : ILeftNavFactory
    {
        public LeftNav BuildLeftNav(string selectedItemName, string[] userRoles)
        {
            var leftNav = new LeftNav();

            if (null != userRoles && userRoles.Length > 0 && (userRoles.ToList().Contains("Administrator") || userRoles.ToList().Contains("SuperUser")))
            {
                var requests = new LeftNavSection { Links = { new Link(LeftNavigationItems.Requests, "/request", string.Equals(LeftNavigationItems.Requests, selectedItemName) ? "active" : string.Empty, "icon") } };
                leftNav.LeftNavSections.Add(requests);
            }

            var questions = new LeftNavSection { Links = { new Link(LeftNavigationItems.Questions, "/question", string.Equals(LeftNavigationItems.Questions, selectedItemName) ? "active" : string.Empty, "icon") } };
            leftNav.LeftNavSections.Add(questions);

            return leftNav;
        }
    }
}