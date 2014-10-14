using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using ATU.Domain.Abstract;
using ATU.Domain.Concrete;
using ATU.Domain.Data.Repository.Concrete;
using ATU.Web.Domain.Model.Authentication;

namespace ATU.Web.Interface.Api
{
    [EnableCors("*", "*", "*")]
    public class RegistrationController : ApiControllerBase
    {
        private readonly IClientAuthenticationService _clientAuthenticationService = new ClientAuthenticationService(new ATURepository(), new ClientService(new ATURepository()));
        public HttpResponseMessage Post([FromBody] RegistrationFields value)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = "Model invalid" };
            }
            var authHash = _clientAuthenticationService.CreateAccount(value.DisplayName);
            var response = Request.CreateResponse(HttpStatusCode.Created, authHash);

            return response;
        }
    }
}