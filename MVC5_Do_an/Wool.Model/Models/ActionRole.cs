using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class ActionRole
    {
        public long ID { get; set; }
        public long WebActionId { get; set; }
        public string RoleId { get; set; }

        public virtual WebAction WebAction { get; set; }
        public virtual Role Role { get; set; }
    }
}
