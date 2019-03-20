using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ContextFolder
{
   public class Context:DbContext
    {
        public Context():base("LibraryData")
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }

    }
}
