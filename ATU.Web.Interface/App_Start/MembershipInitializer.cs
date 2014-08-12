using System;
using System.Web.Security;
using ATU.Domain;
using WebMatrix.WebData;

namespace ATU.Web.Interface
{
    public class MembershipInitializer
    {
        public static void InitializeMembership()
        {
            if (WebSecurity.Initialized) return;

            try
            {
                WebSecurity.InitializeDatabaseConnection("ATU.Data", "User", "UserId", "UserName", autoCreateTables: true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }

            try
            {
                InitializeRoles();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Membership database could not initialize it's roles. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }

        private static void InitializeRoles()
        {
            InitializeRole(RoleNames.SuperUser);
            InitializeRole(RoleNames.Administrator);
            InitializeRole(RoleNames.Editor);
        }

        private static void InitializeRole(string roleName)
        {
            if (!Roles.RoleExists(roleName))
                Roles.CreateRole(roleName);
        }
    }
}