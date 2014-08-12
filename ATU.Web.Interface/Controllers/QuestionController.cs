using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ATU.Domain.Abstract;
using ATU.Domain.Model;
using ATU.Web.Domain.Abstract;
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
            var items = _questionService.GetAll().ToList();
            var viewModel = _viewFactory.BuildQuestionIndexViewModel(Roles.GetRolesForUser(), "Questions", items, new List<int>() { 10, 20, 50 });

            return View(viewModel);
        }

        public ActionResult Detail(int id)
        {
            var question = _questionService.Get(id);
            var questionFields = Mapper.Map<Question, QuestionFields>(question);

            var viewModel = _viewFactory.BuildQuestionDetailViewModel(Roles.GetRolesForUser(), "Question Detail", questionFields);

            return View(viewModel);
        }
    }
}