using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration() {
            ToTable("Suppliers");
            Property(customer => customer.ID).IsRequired();
            Property(customer => customer.Name).IsRequired().HasMaxLength(50);
            Property(customer => customer.Email).IsRequired().HasMaxLength(50);
            Property(customer => customer.Logo).IsRequired().HasMaxLength(50);
            Property(customer => customer.Phone).IsRequired().HasMaxLength(50);
        }
    }
}
