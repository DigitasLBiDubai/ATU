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

            Mapper.CreateMap<Question, QuestionApiListItem>();
            Mapper.CreateMap<QuestionApiListItem, Question>();

            // Answer
            Mapper.CreateMap<Answer, AnswerFields>();
            Mapper.CreateMap<AnswerFields, Answer>();

            Mapper.CreateMap<Answer, AnswerApiListItem>();
            Mapper.CreateMap<AnswerApiListItem, Answer>();
        }
    }
}