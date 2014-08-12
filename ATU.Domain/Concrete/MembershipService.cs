using ATU.Domain.Abstract;
using ATU.Domain.Data.Repository.Abstract;

namespace ATU.Domain.Concrete
{
    public class MembershipService : BaseService, IMembershipService
    {
        public MembershipService(IRepository repo) : base(repo) { }

        public void DeployMembershipRepository() 
        {
            Repo.DeployMembershipDatabase();
        }
    }
}