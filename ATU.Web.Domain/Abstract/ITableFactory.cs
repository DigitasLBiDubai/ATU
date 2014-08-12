using System.Collections.Generic;
using ATU.Domain.Model;
using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Abstract
{
    public interface ITableFactory
    {
        Table BuildRequestsTable(IEnumerable<Request> requests, List<int> itemsPerPage, string title);
        Table BuildRequestsTable(IEnumerable<Request> requests, List<int> itemsPerPage, string title, int status);

        Table BuildQuestionsTable(IEnumerable<Question> questions, List<int> itemsPerPage, string title);
    }
}