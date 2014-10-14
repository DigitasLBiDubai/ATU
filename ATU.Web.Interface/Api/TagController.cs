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
    [EnableCors("*", "*", "*")]
    public class TagController : ApiControllerBase
    {
        private readonly ITagService _tagService = new TagService(new ATURepository());

        public HttpResponseMessage Get()
        {
            var tags = _tagService.GetAll().ToList();
            var tagListitems = Mapper.Map<List<Tag>, List<TagApiListItem>>(tags);
            var response = Request.CreateResponse(HttpStatusCode.OK, tagListitems);

            return response;
        }
    }
}