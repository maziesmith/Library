using DAL.Repositories;
using Domain;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public class LibraryService : ILibraryService
    {
        // private object _libRepo;
        private IRepository<Library> _libRepo;
        private IRepository<Lending> _lendRepo;
        private IRepository<Book> _bookRepo;
        private IRepository<Client> _cliRepo;
        private IRepository<Publisher> _pubRepo;
        private IRepository<BookCopy> _bCpyRepo;

        public LibraryService(IRepository<Library> libRepo,
                              IRepository<Lending> lendRepo,
                              IRepository<Book> bookRepo,
                              IRepository<Client> cliRepo,
                              IRepository<Publisher> pubRepo,
                              IRepository<BookCopy> bCpyRepo)
        {
            _libRepo = libRepo;
            _lendRepo = lendRepo;
            _bookRepo = bookRepo;
            _cliRepo = cliRepo;
            _pubRepo = pubRepo;
            _bCpyRepo = bCpyRepo;
        }

        
        public IEnumerable<Library> GetAllLibraries()
        {
            return _libRepo.GetAllWithInclude(x => x.BookCopies);
        }
       
       public Lending Lend(Lending lend)
        {
            lend.DateReturned = DateTime.Now;
            lend = _lendRepo.Update(lend);
            return lend;
        }
        
        public void InsertLibrary(Library library)
        {
            _libRepo.Insert(library);
        }
        public void UpdateLibrary(Library library)
        {
            _libRepo.Update(library);
        }
        public void DeleteLibrary(Library library)
        {
            _libRepo.Delete(library);
        }
        public Library GetLibrary(int id)
        {
            return _libRepo.FindEntity(id);

        }

        public Library GetWithInclude(int id, params Expression<Func<Library, object>>[] Include)
        {
            var library = _libRepo.GetAllWithInclude(Include).FirstOrDefault(x=>x.LibraryID==id);
            return library;
        }
    }
}
