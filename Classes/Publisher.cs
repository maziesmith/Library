using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain

{
    public class Publisher
    {
        public Publisher()
        {
            Books = new List<Book>();
        }
        public int PublisherID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public ICollection<Book> Books { get; private set; }
    }
}
