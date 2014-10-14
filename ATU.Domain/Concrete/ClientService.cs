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
    public class ClientService : BaseService, IClientService
    {
        public ClientService(IRepository repo) : base(repo) { }

        public Client Get(int id)
        {
            var item = Repo.Find<Client>(x => x.Id == id);
            if (null != item && item.Any())
                return item.Single();

            return null;
        }

        public Client Get(string username)
        {
            var item = Repo.Find<Client>(x => x.UserName == username);
            if (null != item && item.Any())
                return item.Single();

            return null;
        }

        public IQueryable<Client> GetAll()
        {
            return Repo.GetAll<Client>();
        }

        public Client Create(Client client)
        {
            client.DateLastModified = DateTime.UtcNow;
            client.DateCreated = DateTime.UtcNow;
            return base.Create(client);
        }

        public void Update(Client client)
        {
            client.DateLastModified = DateTime.UtcNow;
            base.Update(client);
        }

        public void Delete(Client client)
        {
            base.Delete(client);
        }

        public bool UserNameTaken(string username)
        {
            return Repo.GetAll<Client>().Any(c => c.UserName == username);
        }

        public bool DisplayNameTaken(string displayname)
        {
            return Repo.GetAll<Client>().Any(c => c.UserName == displayname);
        }
    }
}
