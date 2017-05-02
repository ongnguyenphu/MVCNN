using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Model;

namespace Wool.Data.Repositories
{
    public class MasterRoleRepository : RepositoryBase<MasterRole>, IMasterRoleRepository
    {
        public MasterRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
