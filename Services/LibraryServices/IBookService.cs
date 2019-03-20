using Domain;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public interface IBookService
    {
        void InsertBook(Book book);
        void DeleteBook(Book book);
        void UpdateBook(Book book);
        Book GetBook(int id);
        void DeleteReturnedBook(Lending lending);
        void InsertReturnedBook(Book book);
        IEnumerable<BookModel> GetAllBooks();
        //IEnumerable<BookCopy> GetAllBookCopies();
        IEnumerable<Book> GetAllLendedNotReturned();
        IEnumerable<Book> GetAllLendedAndReturned();
        Book GetBookWithInclude(int id);
    }
}
