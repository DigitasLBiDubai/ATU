using ATU.Domain.Data.Repository.Abstract;

namespace ATU.Domain.Abstract
{
    public class BaseService
    {
        protected IRepository Repo { get; set; }

        protected BaseService(IRepository repo) { Repo = repo; }

        public virtual T Create<T>(T item)
        {
            Repo.Add(item);
            Repo.SaveChanges();

            return item;
        }

        public void Delete<T>(T item)
        {
            Repo.Delete(item);
            Repo.SaveChanges();
        }

        public void Update<T>(T item)
        {
            Repo.SaveChanges();
        }
    }
}
