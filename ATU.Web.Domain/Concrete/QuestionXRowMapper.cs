using ATU.Domain.Model;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace ATU.Web.Domain.Concrete
{
    public class QuestionXRowMapper : IQuestionXRowMapper
    {
        public IEnumerable<Row> MapQuestionsToRows(IEnumerable<Question> questions)
        {
            if (null == questions || !questions.Any()) return null;

            return questions.Select(MapQuestionToRow).ToList();
        }

        public Row MapQuestionToRow(Question item)
        {
            if (null == item) return null;

            var row = new Row();

            row.Cells.Add(new Cell(new Link(item.Id.ToString(), "/question/detail/" + item.Id, string.Empty), false));
            row.Cells.Add(new Cell(item.Text, false));
            row.Cells.Add(new Cell(item.Text, true));

            return row;
        }
    }
}