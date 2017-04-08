using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class WebActionConfiguration : EntityTypeConfiguration<WebAction>
    {
        public WebActionConfiguration() {
            ToTable("WebActions");
            Property(customer => customer.Name).IsRequired().HasMaxLength(50);
            Property(customer => customer.Description).IsRequired().HasMaxLength(50);
        }
    }
}
