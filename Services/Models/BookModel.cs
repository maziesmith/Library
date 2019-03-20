using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
   public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfIssue { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public int LendingsNr { get; set; }
        public int BookNr { get; set; }

        
    }
}
