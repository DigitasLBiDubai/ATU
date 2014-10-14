using System.Linq;
using ATU.Domain.Model;

namespace ATU.Domain.Abstract
{
    public interface IClientService
    {
        Client Get(int id);
        Client Get(string username);
        IQueryable<Client> GetAll();
        Client Create(Client client);
        void Update(Client client);
        void Delete(Client client);
        bool UserNameTaken(string username);
        bool DisplayNameTaken(string displayname);
    }
}