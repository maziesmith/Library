using DAL.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public class ClientService : IClientService
    {
        private IRepository<Client> _cliRepo;

        public ClientService(IRepository<Client> cliRepo)
        {
            _cliRepo = cliRepo;
        }
        public void InsertClient(Client client)
        {
            _cliRepo.Insert(client);
        }
        public void UpdateClient(Client client)
        {
            _cliRepo.Update(client);
        }
        public void DeleteClient(Client client)
        {
            _cliRepo.Delete(client);
        }
        public IEnumerable<Client> GetAllClients()
        {
            return _cliRepo.GetALl();
        }
        public Client GetClient(int id)
        {
            return _cliRepo.FindEntity(id);
        }
    }
}
