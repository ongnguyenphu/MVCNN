using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Service
{
    public interface IActionRoleService
    {
        IEnumerable<ActionRole> GetActionRoles();
        void CreateActionRole(ActionRole actionRole);
        void DeleteActionRole(ActionRole actionRole);
        void UpdateActionRole(ActionRole actionRole);

        void SaveActionRole();
    }
}
