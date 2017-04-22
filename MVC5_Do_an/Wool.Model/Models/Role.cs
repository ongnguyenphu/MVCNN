using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class Role
    {
        public Role()
        {
            this.ActionRoles = new HashSet<ActionRole>();
            this.MasterRoles = new HashSet<MasterRole>();
        }

        public long ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActionRole> ActionRoles { get; set; }
        public virtual ICollection<MasterRole> MasterRoles { get; set; }
    }
}
