using System.Collections.Generic;
using ATU.Domain.Model;
using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Abstract
{
    public interface IRequestXRowMapper
    {
        IEnumerable<Row> MapRequestsToRows(IEnumerable<Request> requests);
    }
}