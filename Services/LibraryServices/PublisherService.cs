using DAL.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public class PublisherService : IPublisherService
    {
        private IRepository<Publisher> _pubRepo;
        public PublisherService(IRepository<Publisher> pubRepo) {
            _pubRepo = pubRepo;
        }
        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _pubRepo.GetAllWithInclude(x => x.Books);
        }
        public void InsertPublisher(Publisher publisher)
        {
            _pubRepo.Insert(publisher);
        }
        public void UpdatePublisher(Publisher publisher)
        {
            _pubRepo.Update(publisher);
        }
        public void DeletePublisher(Publisher publisher)
        {
            _pubRepo.Delete(publisher);
        }
        public Publisher GetPublisher(int id)
        {
            return _pubRepo.FindEntity(id);
        }
    }
}
