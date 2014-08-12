using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using ATU.Domain.Abstract;
using ATU.Domain.Model;
using ATU.Web.Domain.Abstract;
using ATU.Web.Domain.Model.Answer;
using AutoMapper;

namespace ATU.Web.Interface.Controllers
{
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        private readonly IQuestionService _questionService;

        public AnswerController(IViewFactory viewFactory, IAnswerService answerService, IQuestionService questionService)
            : base(viewFactory)
        {
            _answerService = answerService;
            _questionService = questionService;
        }

        public ActionResult Create()
        {
            var createAnswer = _viewFactory.BuildCreateAnswerViewModel(Roles.GetRolesForUser(), "Create Answer");
            createAnswer.AnswerFields.QuestionId = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);

            return View(createAnswer);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnswerFields model)
        {
            if (ModelState.IsValid)
            {
                var answer = Mapper.Map<AnswerFields, Answer>(model);
                answer.DateCreated = DateTime.UtcNow;
                var question = _questionService.Get(Convert.ToInt32(model.QuestionId));

                if (null == question.Answers) question.Answers = new List<Answer>();

                question.Answers.Add(answer);

                _questionService.Update(question);

                return RedirectToAction("Detail", "Question", new {id=model.QuestionId});
            }

            var createAnswer = _viewFactory.BuildCreateAnswerViewModel(Roles.GetRolesForUser(), "Create Answer", model);

            return View(createAnswer);
        }
    }
}
