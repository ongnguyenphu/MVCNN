using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class WebAction
    {
        public WebAction()
        {
            this.ActionRoles = new HashSet<ActionRole>();
        }

        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ActionRole> ActionRoles { get; set; }
    }
}
