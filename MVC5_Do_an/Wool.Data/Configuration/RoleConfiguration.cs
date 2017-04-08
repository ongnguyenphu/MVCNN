using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration() {
            ToTable("Roles");
            Property(customer => customer.ID).IsRequired().HasMaxLength(50);
            Property(customer => customer.Name).IsRequired().HasMaxLength(50);
        }
    }
}
