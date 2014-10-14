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
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService = new CategoryService(new ATURepository());

        public HttpResponseMessage Get()
        {
            var categories = _categoryService.GetAll().ToList();
            var categoryListitems = Mapper.Map<List<Category>, List<CategoryApiListItem>>(categories);
            var response = Request.CreateResponse(HttpStatusCode.OK, categoryListitems);

            return response;
        }
    }
}