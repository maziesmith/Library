using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BookCopy
    {
        public int BookCopyID { get; set; }
        public virtual Book Book { get; set; }
        public int NumberOfCopies { get; set; }
    //    public Library Library { get; set; }
        public int FK_Book { get; set; }
        public int FK_Library { get; set; }
        public Library Library { get; set; }
    }

}
