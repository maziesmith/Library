using DAL.Repositories;
using Domain;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public class BookService:IBookService
    {
        private IRepository<Book> _bookRepo;
        private IRepository<Lending> _lendRepo;
        private IRepository<BookCopy> _bCpyRepo;

        public BookService(IRepository<Book> bookRepo,
                           IRepository<Lending> lendRepo,
                           IRepository<BookCopy> bCpyRepo)
        {
            _bookRepo = bookRepo;
            _lendRepo = lendRepo;
            _bCpyRepo = bCpyRepo;
        }
        public IEnumerable<Book> GetAllLendedNotReturned()
        {
            var lends = _lendRepo.GetMany(x => !x.DateReturned.HasValue);
            var booksIds = lends.Select(x => x.FK_Book).ToList();
            var Books = _bookRepo.GetMany(x => booksIds.Contains(x.BookID));
            return Books;

        }
        public IEnumerable<Book> GetAllLendedAndReturned()
        {
            var lends = _lendRepo.GetMany(x => x.DateReturned.HasValue);
            var booksIds = lends.Select(x => x.FK_Book).ToList();
            var Books = _bookRepo.GetMany(x => booksIds.Contains(x.BookID));
            return Books;
        }
        public void InsertReturnedBook(Book book)
        {

            var Lends = new Lending()
            {
                DateReturned = DateTime.Now,
                FK_Book = book.BookID,
                FK_Client = 1
            };
            _lendRepo.Insert(Lends);
        }
        public void DeleteReturnedBook(Lending lend)
        {
            lend.DateReturned = DateTime.Now;
            _lendRepo.Delete(lend);
        }
        public void InsertBook(Book book)
        {
            _bookRepo.Insert(book);
        }
        public void DeleteBook(Book book)
        {
            _bookRepo.Delete(book);
        }
        public void UpdateBook(Book book)
        {
            _bookRepo.Update(book);
        }
        public Book GetBook(int id)
        {
            return _bookRepo.FindEntity(id);
        }
        public Book GetBookWithInclude(int id)
        {
            return _bookRepo.GetAllWithInclude(x => x.Publisher, x => x.Lendings, x => x.BookCopies).FirstOrDefault(x => x.BookID == id);
        }
        public IEnumerable<BookModel> GetAllBooks()
        {
           

            var bookModels= _bookRepo.GetAllWithInclude(x => x.Publisher,x=>x.BookCopies,x=>x.Lendings).Select(x => x.ToModel()).ToList();
            //for (int i = 0; i < bookModels.Count; i++)
            //{
            //    var current = bookModels[i];
            //    var Lendings = _lendRepo.GetMany(x => x.FK_Book == current.Id).Select(x => x.LendingID) == null ? 0
            //                              : _lendRepo.GetMany(x => x.FK_Book == current.Id).Select(x => x.LendingID).Count();

            //    var bookCopies= _bCpyRepo.GetMany(x => x.FK_Book == current.Id).Select(x => x.BookCopyID) == null ? 0
            //                              : _bCpyRepo.GetMany(x => x.FK_Book == current.Id).Select(x => x.BookCopyID).Count();
            //    current.BookNr = bookCopies;
            //    current.LendingsNr = Lendings;
            //}
            return bookModels;
            //return _bookRepo.GetAllWithInclude(x => x.Publisher).Select(x => x.ToModel(service, lendService));
        }
        
    }
}
