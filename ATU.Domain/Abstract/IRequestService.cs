using System.Linq;
using ATU.Domain.Model;

namespace ATU.Domain.Abstract
{
    public interface IRequestService
    {
        Request GetRequest(int id);
        IQueryable<Request> GetRequests();
        Request CreateRequest(Request request, RequestTypes requestType);
        void UpdateRequest(Request request);
        void AcceptRequest(int id);
        void RejectRequest(int id);
        void ResetToNew(int id);
    }
}