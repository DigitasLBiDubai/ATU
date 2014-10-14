
using System.Collections.Generic;
using ATU.Web.Domain.Model.Answer;

namespace ATU.Web.Domain.Model.Question
{
    public class QuestionDetail : ViewBase
    {
        public QuestionFields QuestionFields { get; set; }
        public List<AnswerFields> Answers { get; set; }
        public string Poster { get; set; }

    }
}
