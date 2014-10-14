using System.Net.Http.Formatting;
using Autofac;
using ATU.Domain.Abstract;
using ATU.Web.Domain.Concrete;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace ATU.Web.Interface
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private IContainer _container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            _container = IocConfig.Initialise();
            _container.Resolve<ModelMapper>().Configure();

            var membershipService = _container.Resolve<IMembershipService>();
            MembershipConfig.DeployMembershipRepository(membershipService);
            
            if (!WebSecurity.Initialized)
                MembershipInitializer.InitializeMembership();
        }
    }
}