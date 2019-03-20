using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Book
    {
        public Book()
        {
            BookCopies = new List<BookCopy>();
            }
        public int BookID { get; set; }
        public string Title { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
        public Publisher Publisher { get; set; }
        public int FK_Publisher { get; set; }
        public ICollection<Lending> Lendings { get; set; }
        public ICollection<BookCopy> BookCopies { get; set; }

     //   public Lending Lending { get; set; }
           
    }
    
 
}
