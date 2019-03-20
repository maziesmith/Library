using DAL.Repositories;
using Domain;
using Services.LibraryServices;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ModelFactory
    {
        public static BookModel ToModel(this Book book)
        {
            
          
            var PublisherName = book.Publisher == null ? "" : book.Publisher.Name;
            return new BookModel()
            {
                LendingsNr = book.Lendings.Count,
                BookNr = book.BookCopies.Count,
                Publisher = PublisherName,
                Id=book.BookID,
                NumberOfPages=book.NumberOfPages,
                Title=book.Title,
                YearOfIssue=book.YearOfIssue,
                
            };
        }
    }
}
