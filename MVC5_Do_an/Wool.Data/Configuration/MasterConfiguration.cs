using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class MasterConfiguration : EntityTypeConfiguration<Master>
    {
        public MasterConfiguration() {
            ToTable("Masters");
            Property(master => master.Password).IsRequired().HasMaxLength(50);
            Property(master => master.FullName).IsRequired().HasMaxLength(50);
            Property(master => master.Email).IsRequired().HasMaxLength(50);
            Property(master => master.Mobile).IsRequired().HasMaxLength(50);
        }
    }
}
