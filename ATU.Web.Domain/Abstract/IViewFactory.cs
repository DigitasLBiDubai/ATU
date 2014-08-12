using System.Collections.Generic;
using ATU.Domain.Model;
using ATU.Web.Domain.Model.Answer;
using ATU.Web.Domain.Model.Question;
using ATU.Web.Domain.Model.Request;

namespace ATU.Web.Domain.Abstract
{
    public interface IViewFactory
    {
        RequestIndex BuildRequestIndexViewModel(string[] userRoles, string title, IEnumerable<Request> requests, List<int> itemsPerPage);
        RequestDetail BuildRequestDetailViewModel(string[] userRoles, string title, RequestFields requestFields);

        QuestionIndex BuildQuestionIndexViewModel(string[] userRoles, string title, IEnumerable<Question> questions, List<int> itemsPerPage);
        QuestionDetail BuildQuestionDetailViewModel(string[] userRoles, string title, QuestionFields questionFields);

        CreateAnswer BuildCreateAnswerViewModel(string[] userRoles, string title);
        CreateAnswer BuildCreateAnswerViewModel(string[] userRoles, string title, AnswerFields answerFields);
    }
}