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
            Property(product => product.UnitPrice).IsRequired();
            Property(product => product.UnitBrief).IsRequired();
            Property(product => product.Image).IsRequired();
            Property(product => product.Available).IsRequired();
            Property(product => product.ProductDate).IsRequired();
            Property(product => product.CategoryID).IsRequired();
            Property(product => product.SupplierID).IsRequired();
            Property(product => product.Quantity).IsRequired();
            Property(product => product.Discount).IsRequired();
            Property(product => product.Special).IsRequired();
            Property(product => product.Latest).IsRequired();
            Property(product => product.Views).IsRequired();
        }
    }
}
