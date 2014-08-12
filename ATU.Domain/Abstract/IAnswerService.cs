using System.Linq;
using ATU.Domain.Model;

namespace ATU.Domain.Abstract
{
    public interface IAnswerService
    {
        Answer Get(int id);
        IQueryable<Answer> GetAll();
        Answer Create(Answer answer);
        void Update(Answer answer);
    }
}