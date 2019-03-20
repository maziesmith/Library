using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public interface IClientService
    {
        void InsertClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
        IEnumerable<Client> GetAllClients();
        Client GetClient(int id);

    }
}
