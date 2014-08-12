using System.Linq;
using ATU.Domain.Model;

namespace ATU.Domain.Abstract
{
    public interface IQuestionService
    {
        Question Get(int id);
        IQueryable<Question> GetAll();
        Question Create(Question question);
        void Update(Question question);
    }
}