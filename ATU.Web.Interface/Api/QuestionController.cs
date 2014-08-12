using ATU.Domain.Abstract;
using ATU.Domain.Concrete;
using ATU.Domain.Data.Repository.Concrete;
using ATU.Domain.Model;
using ATU.Web.Domain.Model.Question;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ATU.Web.Interface.Api
{
    [EnableCors("*", "*", "*")]
    public class QuestionController : ApiController
    {
        private readonly IQuestionService _questionService = new QuestionService(new ATURepository());

        public HttpResponseMessage Get()
        {
            var questions = _questionService.GetAll().ToList();
            var questionListItems = Mapper.Map<List<Question>, List<QuestionApiListItem>>(questions);

            var response = Request.CreateResponse(HttpStatusCode.OK, questionListItems);

            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var question = _questionService.Get(id);
            var questionListItem = Mapper.Map<Question, QuestionApiListItem>(question);

            var response = Request.CreateResponse(HttpStatusCode.OK, questionListItem);

            return response;
        }

        public HttpResponseMessage Post([FromBody]QuestionFields value)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Model invalid" };
            }

            var question = Mapper.Map<QuestionFields, Question>(value);

            _questionService.Create(question);
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, ReasonPhrase = "Request Question" };
        }
    }
}