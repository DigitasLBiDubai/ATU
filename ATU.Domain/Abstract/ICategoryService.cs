using System.Linq;
using ATU.Domain.Model;

namespace ATU.Domain.Abstract
{
    public interface ICategoryService
    {
        Category Get(int id);
        IQueryable<Category> GetAll();
    }
}