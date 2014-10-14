using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATU.Domain.Abstract;
using ATU.Domain.Data.Repository.Abstract;
using ATU.Domain.Model;

namespace ATU.Domain.Concrete
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IRepository repo) : base(repo)
        {
            
        }

        public Category Get(int id)
        {
            var item = Repo.Find<Category>(x => x.Id == id);
            if (null != item && item.Any())
                return item.Single();

            return null;
        }

        public IQueryable<Category> GetAll()
        {
            return Repo.GetAll<Category>();
        }
    }
}
