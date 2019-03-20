using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public interface IPublisherService
    {
        IEnumerable<Publisher> GetAllPublishers();
        void InsertPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
        Publisher GetPublisher(int id);
    }
}
