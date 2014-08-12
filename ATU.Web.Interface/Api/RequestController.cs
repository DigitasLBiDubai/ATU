using ATU.Domain;
using ATU.Domain.Abstract;
using ATU.Domain.Concrete;
using ATU.Domain.Data.Repository.Concrete;
using ATU.Domain.Model;
using ATU.Web.Domain.Model.Request;
using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ATU.Web.Interface.Api
{
    public class RequestController : ApiControllerBase
    {
        private readonly IRequestService _requestService = new RequestService(new ATURepository(), new PasswordGenerator(new ConfigurationService()), new RegistrationService(new ATURepository()));

        public HttpResponseMessage Post([FromBody]RequestFields value)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage {StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Model invalid"};
            }

            var request = Mapper.Map<RequestFields, Request>(value);
            request.Status = (int)RequestStatus.New;

            _requestService.CreateRequest(request, (RequestTypes) request.RequestType);
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, ReasonPhrase = "Request Created" };
        }
    }
}
