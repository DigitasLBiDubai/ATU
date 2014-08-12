using System.Collections.Generic;
using ATU.Domain.Model;
using ATU.Web.Domain.Model;

namespace ATU.Web.Domain.Abstract
{
    public interface IQuestionXRowMapper
    {
        IEnumerable<Row> MapQuestionsToRows(IEnumerable<Question> questions);
    }
}