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
    public class ClientAuthenticationService : BaseService, IClientAuthenticationService
    {
        private readonly IClientService _clientService;

        public ClientAuthenticationService(IRepository repo, IClientService clientService) : base(repo)
        {
            _clientService = clientService;
        }

        public string CreateAccount(string displayName)
        {
            var client = new Client();
            
            //check if username or displayname is taken
            client.UserName = displayName;
            if (_clientService.UserNameTaken(client.UserName))
                return string.Empty;

            client.Password = Guid.NewGuid().ToString();
            client.Hash = Guid.NewGuid();
            client.DisplayName = displayName;
            client.Email = "abc@ab.abc";
            _clientService.Create(client);
            return client.Hash.ToString();
        }

        public string Login(string username, string password)
        {
            var client = _clientService.Get(username);
            if (client.Password == password)
                return client.Hash.ToString();
            return string.Empty;
        }
    }
}
