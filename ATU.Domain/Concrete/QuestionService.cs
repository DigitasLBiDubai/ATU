using System;
using System.Linq;
using ATU.Domain.Abstract;
using ATU.Domain.Data.Repository.Abstract;
using ATU.Domain.Model;

namespace ATU.Domain.Concrete
{
    public class QuestionService : BaseService, IQuestionService
    {
        public QuestionService(IRepository repo) : base(repo) { }

        public Question Get(int id)
        {
            var item = Repo.Find<Question>(x => x.Id == id);
            if (null != item && item.Any())
                return item.Single();

            return null;
        }

        public IQueryable<Question> GetAll()
        {
            return Repo.GetAll<Question>();
        }

        public Question Create(Question question)
        {
            question.DateCreated = DateTime.UtcNow;
            return base.Create(question);
        }

        public void Update(Question question)
        {
            base.Update(question);
        }

        public void Delete(Question question)
        {
            base.Delete(question);
        }
    }
}