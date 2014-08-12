using ATU.Domain.Abstract;

namespace ATU.Web.Interface
{
    public static class MembershipConfig
    {
        public static void DeployMembershipRepository(IMembershipService membershipService) 
        {
            membershipService.DeployMembershipRepository();
        }
    }
}