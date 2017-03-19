using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration() {
            ToTable("Categories");
            Property(category => category.Name).IsRequired().HasMaxLength(50);
        }
    }
}
