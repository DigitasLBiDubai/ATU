using ATU.Domain.Model;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace ATU.Web.Domain.Concrete
{
    public class RequestXRowMapper : IRequestXRowMapper
    {
        public IEnumerable<Row> MapRequestsToRows(IEnumerable<Request> requests)
        {
            if (null == requests || !requests.Any()) return null;

            return requests.Select(MapRequestToRow).ToList();
        }

        public Row MapRequestToRow(Request item)
        {
            if (null == item) return null;

            var row = new Row();

            row.Cells.Add(new Cell(new Link(item.Id.ToString(), "/request/detail/" + item.Id, string.Empty), false));
            row.Cells.Add(new Cell(string.Concat(item.FirstName, " ", item.LastName), false));
            row.Cells.Add(new Cell(item.Email, true));

            return row;
        }
    }
}