using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.LibraryServices
{
    public interface IBookCopiesService
    {
        IEnumerable<BookCopy> GetAllBookCopies();
        int BookCopyNr(int LibId);
        void InsertBookCopy(BookCopy bookCopy);
        void UpdateBookCopy(BookCopy bookCopy);
        void DeleteBookCopy(BookCopy bookCopy);
        BookCopy GetBookCopy(int id);
        //BookCopy GetBookCopyWithInclude(int id);
        IEnumerable<BookCopy> GetAllBookCopiesWithInclude(params Expression<Func<BookCopy,object>>[] include);
    }
}
