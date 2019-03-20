using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    class PublisherConfiguration : EntityTypeConfiguration<Publisher>
    {
        public PublisherConfiguration() {
            HasMany(x => x.Books).WithRequired(x => x.Publisher).HasForeignKey(x => x.FK_Publisher);
            HasKey(x => x.PublisherID);
            HasIndex(x => x.PublisherID).IsUnique();
            }
    }
}
