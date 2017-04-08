using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration() {
            ToTable("Customers");
            Property(customer => customer.ID).IsRequired().HasMaxLength(20);
            Property(customer => customer.Password).IsRequired().HasMaxLength(50);
            Property(customer => customer.FullName).IsRequired().HasMaxLength(50);
            Property(customer => customer.Email).IsRequired().HasMaxLength(50);
            Property(customer => customer.Photo).IsRequired().HasMaxLength(50);
            Property(customer => customer.Activated).IsRequired();
        }
    }
}
