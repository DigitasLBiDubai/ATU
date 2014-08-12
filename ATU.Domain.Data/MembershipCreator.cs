using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ATU.Domain.Data
{
    public static class MembershipCreator
    {
        public static void DeployMembershipDatabase()
        {
            Database.SetInitializer<ATUContext>(null);

            try
            {
                using (var context = new ATUContext())
                {
                    if (!context.Database.Exists())
                    {
                        // Create the SimpleMembership database without Entity Framework migration schema
                        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("The ASP.NET Simple Membership database could not be created. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
}
