using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class MasterRoleConfiguration : EntityTypeConfiguration<MasterRole>
    {
        public MasterRoleConfiguration() {
            ToTable("MasterRoles");
            Property(masterRole => masterRole.ID).IsRequired();
            Property(masterRole => masterRole.MasterId).IsRequired().HasMaxLength(50);
            Property(masterRole => masterRole.RoleId).IsRequired().HasMaxLength(50);
        }
    }
}
