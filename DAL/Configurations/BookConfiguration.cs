using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    class BookConfiguration:EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            HasMany(x => x.BookCopies).WithRequired(x => x.Book).HasForeignKey(x => x.FK_Library); 
            HasKey(x => x.BookID);
            HasIndex(x => x.BookID).IsUnique();

            HasMany(x => x.Lendings).WithRequired(x => x.Book).HasForeignKey(x => x.FK_Client);
            

            HasRequired(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.FK_Publisher);
            

        }
    }
}
