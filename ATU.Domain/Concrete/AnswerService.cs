using System;
using System.Linq;
using ATU.Domain.Abstract;
using ATU.Domain.Data.Repository.Abstract;
using ATU.Domain.Model;

namespace ATU.Domain.Concrete
{
    public class AnswerService : BaseService, IAnswerService
    {
        public AnswerService(IRepository repo) : base(repo) { }

        public Answer Get(int id)
        {
            var item = Repo.Find<Answer>(x => x.Id == id);
            if (null != item && item.Any())
                return item.Single();

            return null;
        }

        public IQueryable<Answer> GetAll()
        {
            return Repo.GetAll<Answer>();
        }

        public Answer Create(Answer answer)
        {
            answer.DateCreated = DateTime.UtcNow;
            return base.Create(answer);
        }

        public void Update(Answer answer)
        {
            base.Update(answer);
        }

        public void Delete(Answer answer)
        {
            base.Delete(answer);
        }
    }
}