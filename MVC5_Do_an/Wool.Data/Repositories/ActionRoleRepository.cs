using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Model;

namespace Wool.Data.Repositories
{
    public class ActionRoleRepository : RepositoryBase<ActionRole>, IActionRoleRepository
    {
        public ActionRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
