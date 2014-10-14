using System.Collections.Generic;
using ATU.Web.Domain.Model.Answer;
using ATU.Web.Domain.Model.Question;
using AutoMapper;
using ATU.Domain.Model;
using ATU.Web.Domain.Model;
using ATU.Web.Domain.Model.Request;

namespace ATU.Web.Domain.Concrete
{
    public class ModelMapper
    {
        public void Configure()
        {
            // User
            Mapper.CreateMap<User, RegisterModel>();
            Mapper.CreateMap<RegisterModel, User>();

            Mapper.CreateMap<UserProfile, RegisterModel>();
            Mapper.CreateMap<RegisterModel, UserProfile>();

            // Request
            Mapper.CreateMap<Request, RequestFields>();
            Mapper.CreateMap<RequestFields, Request>();

            Mapper.CreateMap<Request, User>();
            Mapper.CreateMap<User, Request>();

            Mapper.CreateMap<Request, UserProfile>();
            Mapper.CreateMap<UserProfile, Request>();

            // Question
            Mapper.CreateMap<Question, QuestionFields>();
            Mapper.CreateMap<QuestionFields, Question>();

            // Answer
            Mapper.CreateMap<Answer, AnswerFields>();
            Mapper.CreateMap<AnswerFields, Answer>();

           
            Mapper.CreateMap<AnswerApiListItem, Answer>();
            Mapper.CreateMap<Question, QuestionApiListItem>().ForMember( dest => dest.Answers, opts => opts.MapFrom(src => src.Answers));;
            Mapper.CreateMap<Answer, AnswerApiListItem>();
            Mapper.CreateMap<QuestionApiListItem, Question>();

            // Tag
            Mapper.CreateMap<Tag, TagApiListItem>();
            Mapper.CreateMap<TagApiListItem, Tag>();

            // Category
            Mapper.CreateMap<Category, CategoryApiListItem>();
            Mapper.CreateMap<CategoryApiListItem, Category>();
        }
    }
}