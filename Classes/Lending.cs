using System;
using System.Collections.Generic;

namespace Domain
{
    public class Lending
    {
        public int LendingID { get; set; }
        public Book Book { get; set; }
        public Client Client { get; set; }
        public DateTime DateLending { get; set; }
        public DateTime? DateReturned { get; set; }

        public int FK_Book { get; set; }
        public int FK_Client { get; set; }

        //public ICollection<Client> Clients { get; set; }


    }

}
