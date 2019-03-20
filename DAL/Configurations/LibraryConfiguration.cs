using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class LibraryConfiguration:EntityTypeConfiguration<Library>
    {
        public LibraryConfiguration()
        {
            HasMany(x => x.BookCopies).WithRequired(x => x.Library).HasForeignKey(x => x.FK_Library);
            HasKey(x => x.LibraryID);
            HasIndex(x => x.LibraryID).IsUnique();
            
            
        }
    }
}
