using System.Web.Security;

namespace ATU.Domain.Abstract
{
    public interface IMembershipCreateStatusToErroMapper
    {
        string ErrorCodeToString(MembershipCreateStatus createStatus);
    }
}