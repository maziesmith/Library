using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Library
    {
        public Library()
        {
            BookCopies = new List<BookCopy>();
        }
        public int LibraryID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public ICollection<BookCopy> BookCopies { get; set; }
    }
  
}
