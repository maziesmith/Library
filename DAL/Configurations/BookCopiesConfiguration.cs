using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    class BookCopiesConfiguration : EntityTypeConfiguration<BookCopy>
    {
        public BookCopiesConfiguration() {
            HasRequired(x => x.Book).WithMany(x => x.BookCopies).HasForeignKey(x => x.FK_Book);
            HasKey(x => x.BookCopyID);
            HasIndex(x => x.BookCopyID).IsUnique();
            HasRequired(x => x.Library).WithMany(x => x.BookCopies).HasForeignKey(x => x.FK_Library);
            
            
}
    }
}
