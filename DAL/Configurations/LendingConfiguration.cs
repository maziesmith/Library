using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    class LendingConfiguration:EntityTypeConfiguration<Lending>
    {
        public LendingConfiguration()
        {
            HasOptional(x => x.Book).WithMany(x => x.Lendings).HasForeignKey(x => x.FK_Client);
            HasKey(x => x.LendingID);
            HasIndex(x => x.LendingID).IsUnique();

            HasRequired(x => x.Client).WithMany(x => x.Lendings).HasForeignKey(x => x.FK_Client);
            
        }
    }
}
