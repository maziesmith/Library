using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    class ClientConfiguration:EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            HasMany(x => x.Lendings).WithRequired(x => x.Client).HasForeignKey(x => x.FK_Book);
            HasKey(x => x.ClientID);
            HasIndex(x => x.ClientID).IsUnique();
        }
    }
}
