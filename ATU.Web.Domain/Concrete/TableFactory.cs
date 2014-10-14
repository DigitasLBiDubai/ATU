using ATU.Domain.Model;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace ATU.Web.Domain.Concrete
{
    public class TableFactory : ITableFactory
    {
        private readonly IRequestXRowMapper _requestsXRowsMapper;
        private readonly IQuestionXRowMapper _questionXRowMapper;

        public TableFactory(IRequestXRowMapper requestsXRowsMapper, IQuestionXRowMapper questionXRowMapper)
        {
            _requestsXRowsMapper = requestsXRowsMapper;
            _questionXRowMapper = questionXRowMapper;
        }

        public Table BuildRequestsTable(IEnumerable<Request> requests, List<int> itemsPerPage, string title)
        {
            var table = new Table
            {
                Title = title,
                ItemsPerPage = itemsPerPage,
                TableHeaders = new List<string> { "Id", "Name", "Description" },
                Rows = _requestsXRowsMapper.MapRequestsToRows(requests).ToList()
            };

            return table;
        }

        public Table BuildRequestsTable(IEnumerable<Request> requests, List<int> itemsPerPage, string title, int status)
        {
            var requestOfStatus = requests.Where(r => r.Status == status);

            if (null == requestOfStatus || !requestOfStatus.Any()) return null;

            var table = new Table
            {
                Title = title,
                ItemsPerPage = itemsPerPage,
                TableHeaders = new List<string> { "Id", "Name", "Description" },
                Rows = _requestsXRowsMapper.MapRequestsToRows(requestOfStatus).ToList()
            };

            return table;
        }

        public Table BuildQuestionsTable(IEnumerable<Question> questions, List<int> itemsPerPage, string title)
        {
            if (null == questions || !questions.Any()) return null;

            var table = new Table
            {
                Title = title,
                ItemsPerPage = itemsPerPage,
                TableHeaders = new List<string> { "Status", "Question", "Category"},
                Rows = _questionXRowMapper.MapQuestionsToRows(questions).ToList()
            };

            return table;
        }

        //public Table BuildTable<T>(IEnumerable<T> events, List<int> itemsPerPage, string title)
        //{
        //    var table = new Table
        //    {
        //        Title = title,
        //        ItemsPerPage = itemsPerPage,
        //        TableHeaders = new List<string> { "Id", "Name", "Description" },
        //        Rows = _eventXRowMapper.MapEventsToRows(events).ToList()
        //    };

        //    return table;
        //}
    }
}