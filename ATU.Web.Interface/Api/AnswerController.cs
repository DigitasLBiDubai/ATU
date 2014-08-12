using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ATU.Domain.Abstract;
using ATU.Domain.Concrete;
using ATU.Domain.Data.Repository.Concrete;
using ATU.Domain.Model;
using ATU.Web.Domain.Model.Answer;
using AutoMapper;

namespace ATU.Web.Interface.Api
{
    [EnableCors("*", "*", "*")]
    public class AnswerController : ApiController
    {
        private readonly IAnswerService _answerService = new AnswerService(new ATURepository());

        public HttpResponseMessage Get()
        {
            var result = new string[] { "value1", "value2" };
            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var question = _answerService.Get(id);
            var questionListItem = Mapper.Map<Answer, AnswerApiListItem>(question);

            var response = Request.CreateResponse(HttpStatusCode.OK, questionListItem);

            return response;
        }
    }
}