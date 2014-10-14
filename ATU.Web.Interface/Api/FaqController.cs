using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Cors;
using ATU.Domain.Abstract;
using ATU.Domain.Concrete;
using ATU.Domain.Data.Repository.Concrete;
using ATU.Domain.Model;
using ATU.Web.Domain.Model.Question;
using AutoMapper;

namespace ATU.Web.Interface.Api
{
    public class FaqController :  ApiControllerBase
    {
        private readonly IQuestionService _questionService = new QuestionService(new ATURepository());

        [EnableCors("*", "*", "*")]
        public HttpResponseMessage Get()
        {
            var questions = _questionService.GetAll().Where(q => q.Faq).ToList();
            var questionListItems = Mapper.Map<List<Question>, List<QuestionApiListItem>>(questions);

            var response = Request.CreateResponse(HttpStatusCode.OK, questionListItems);

            return response;
        }
    }
}