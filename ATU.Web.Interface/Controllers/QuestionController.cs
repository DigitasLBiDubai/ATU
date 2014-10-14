using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ATU.Domain.Abstract;
using ATU.Domain.Model;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model.Answer;
using ATU.Web.Domain.Model.Question;
using AutoMapper;

namespace ATU.Web.Interface.Controllers
{
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IViewFactory viewFactory, IQuestionService questionService) : base(viewFactory)
        {
            _questionService = questionService;
        }

        public ActionResult Index()
        {
            var items = _questionService.GetAll().OrderBy(q => q.Answers.Count).ToList();
            var viewModel = _viewFactory.BuildQuestionIndexViewModel(CurrentUserName, Roles.GetRolesForUser(), "Questions", items, new List<int>() { 10, 20, 50 });

            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            var question = _questionService.Get(id);
            var questionFields = Mapper.Map<Question, QuestionFields>(question);
            var answers = question.Answers;
            var answerFieldsList = Mapper.Map<List<Answer>, List<AnswerFields>>(answers);
            var poster = question.Poster != null ? question.Poster.DisplayName : string.Empty;
            var viewModel = _viewFactory.BuildQuestionDetailViewModel(CurrentUserName, Roles.GetRolesForUser(), "Question Detail", questionFields, answerFieldsList, poster);

            return View(viewModel);
        }
    }
}