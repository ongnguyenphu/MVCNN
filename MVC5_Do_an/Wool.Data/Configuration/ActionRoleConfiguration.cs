using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class ActionRoleConfiguration : EntityTypeConfiguration<ActionRole>
    {
        public ActionRoleConfiguration() {
            ToTable("ActionRoles");
            Property(actionRole => actionRole.ID).IsRequired();
            Property(actionRole => actionRole.RoleId).IsRequired().HasMaxLength(50);
            Property(actionRole => actionRole.ID).IsRequired();
        }
    }
}
