using System.Linq;
using ATU.Domain.Model;

namespace ATU.Domain.Abstract
{
    public interface ITagService
    {
        Tag Get(int id);
        IQueryable<Tag> GetAll();
    }
}