using ATU.Domain;
using System;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security;

namespace ATU.Web.Interface.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static MembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!WebMatrix.WebData.WebSecurity.Initialized)
            {
                // Ensure ASP.NET Simple Membership is initialized only once per app start
                LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            }

            try
            {
                InitializeRoles();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not initialize it's roles. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }

        private void InitializeRoles()
        {
            InitializeRole(RoleNames.SuperUser);
            InitializeRole(RoleNames.Administrator);
            InitializeRole(RoleNames.Editor);
        }

        private void InitializeRole(string roleName)
        {
            if (!Roles.RoleExists(roleName))
                Roles.CreateRole(roleName);
        }
    }
}
