
namespace ATU.Web.Domain.Model.Request
{
    public class RequestIndex : ViewBase
    {
        public Table ContactRequestTable { get; set; }

        public Table NewRequestTable { get; set; }

        public Table AcceptedRequestTable { get; set; }

        public Table RejectedRequestTable { get; set; }
    }
}