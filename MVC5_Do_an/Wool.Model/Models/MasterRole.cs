using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class MasterRole
    {
        public long ID { get; set; }
        public string MasterId { get; set; }
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Master Master { get; set; }
    }
}
