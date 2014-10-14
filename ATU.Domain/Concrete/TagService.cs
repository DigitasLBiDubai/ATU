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
    public class TagService : BaseService, ITagService
    {
        public TagService(IRepository repo) : base(repo)
        {
            
        }

        public Tag Get(int id)
        {
            var item = Repo.Find<Tag>(x => x.Id == id);
            if (null != item && item.Any())
                return item.Single();

            return null;
        }

        public IQueryable<Tag> GetAll()
        {
            return Repo.GetAll<Tag>();
        }
    }
}
