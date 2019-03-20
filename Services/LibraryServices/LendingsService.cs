using DAL.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public class LendingsService : ILendingsService
    {
        private IRepository<Lending> _lendRepo;

        public LendingsService(IRepository<Lending> lendRepo)
        {
            _lendRepo = lendRepo;
        }
        public IEnumerable<Lending> GetAllLendings()
        {
            return _lendRepo.GetAllWithInclude(x => x.Book);
        }
        public void InsertLending(Lending lending)
        {
            _lendRepo.Insert(lending);
        }
        public void UpdateLending(Lending lending)
        {
            _lendRepo.Update(lending);
        }
        public void DeleteLending(Lending lending)
        {
            _lendRepo.Delete(lending);
        }
        public Lending GetLending(int id)
        {
            return _lendRepo.FindEntity(id);
        }
    }
}
