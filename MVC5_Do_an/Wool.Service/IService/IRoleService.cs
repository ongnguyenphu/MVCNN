using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Service
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        void CreateRole(Role role);
        void DeleteRole(Role role);
        void UpdateRole(Role role);

        Role GetByID(long Id);
        void SaveRole();
    }
}
