using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration() {
            ToTable("Products");
            Property(product => product.Name).IsRequired().HasMaxLength(50);
            Property(product => product.Price).IsRequired();
            Property(product => product.CategoryID).IsRequired();
        }
    }
}
