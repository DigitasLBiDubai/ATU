using ATU.Domain.Abstract;
using ATU.Domain.Concrete;
using ATU.Domain.Data.Repository.Concrete;
using ATU.Domain.Model;
using ATU.Web.Domain.Model.Answer;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;

namespace ATU.Web.Interface.Api
{
    [EnableCors("*", "*", "*")]
    public class AnswerController : ApiControllerBase
    {
        private readonly IAnswerService _answerService = new AnswerService(new ATURepository());

        public HttpResponseMessage Get()
        {
            var answers = _answerService.GetAll().ToList();
            var answerItems = Mapper.Map<List<Answer>, List<AnswerApiListItem>>(answers);

            return Request.CreateResponse(HttpStatusCode.OK, answerItems);
        }

        public HttpResponseMessage Get(int id)
        {
            var answer = _answerService.Get(id);
            var answerItem = Mapper.Map<Answer, AnswerApiListItem>(answer);

            return Request.CreateResponse(HttpStatusCode.OK, answerItem);
        }
    }
}