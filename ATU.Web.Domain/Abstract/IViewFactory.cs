using System.Collections.Generic;
using ATU.Domain.Model;
using ATU.Web.Domain.Model.Answer;
using ATU.Web.Domain.Model.Question;
using ATU.Web.Domain.Model.Request;

namespace ATU.Web.Domain.Abstract
{
    public interface IViewFactory
    {
        RequestIndex BuildRequestIndexViewModel(string username, string[] userRoles, string title, IEnumerable<Request> requests, List<int> itemsPerPage);
        RequestDetail BuildRequestDetailViewModel(string username, string[] userRoles, string title, RequestFields requestFields);

        QuestionIndex BuildQuestionIndexViewModel(string username, string[] userRoles, string title, IEnumerable<Question> questions, List<int> itemsPerPage);
        QuestionDetail BuildQuestionDetailViewModel(string username, string[] userRoles, string title, QuestionFields questionFields, List<AnswerFields> answerFieldsList, string poster);

        CreateAnswer BuildCreateAnswerViewModel(string username, string[] userRoles, string title);
        CreateAnswer BuildCreateAnswerViewModel(string username, string[] userRoles, string title, AnswerFields answerFields);
    }
}