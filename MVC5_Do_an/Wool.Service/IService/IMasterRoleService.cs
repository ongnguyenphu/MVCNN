using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Service
{
    public interface IMasterRoleService
    {
        IEnumerable<MasterRole> GetMasterRoles();
        void CreateMasterRole(MasterRole masterRole);
        void DeleteMasterRole(MasterRole masterRole);
        void UpdateMasterRole(MasterRole masterRole);

        void SaveMasterRole();
    }
}
