using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public decimal Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ICollection<Lending> Lendings { get; set; }
    }
   
}
