using DAL.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public class BookCopiesService : IBookCopiesService
    {
        private IRepository<BookCopy> _bCpyRepo;

        public BookCopiesService(IRepository<BookCopy> bCpyRepo)
        {
            _bCpyRepo = bCpyRepo;
        }
        public IEnumerable<BookCopy> GetAllBookCopies()
        {
            return _bCpyRepo.GetAllWithInclude(x => x.Book);
        }
        public void InsertBookCopy(BookCopy bookCopy)
        {
            _bCpyRepo.Insert(bookCopy);
        }
        public void UpdateBookCopy(BookCopy bookCopy)
        {
            _bCpyRepo.Update(bookCopy);
        }
        public void DeleteBookCopy(BookCopy bookCopy)
        {
            _bCpyRepo.Delete(bookCopy);
        }
        public BookCopy GetBookCopy(int id)
        {
            return _bCpyRepo.FindEntity(id);
        }

        public int BookCopyNr(int LibId)
        {
            return _bCpyRepo.Query().Where(x => x.FK_Library == LibId).Count();
        }
        public BookCopy GetBookCopyWithInclude(int id,params Expression<Func<BookCopy,object>>[] include)
        {
            return _bCpyRepo.GetAllWithInclude(include).FirstOrDefault(x => x.BookCopyID == id);
        }
        public IEnumerable<BookCopy> GetAllBookCopiesWithInclude(params Expression<Func<BookCopy, object>>[] include)
        {
            return _bCpyRepo.GetAllWithInclude(include);
        }
    }
}
