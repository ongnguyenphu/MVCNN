using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Model;

namespace Wool.Data.Repositories
{
    public class WebActionRepository : RepositoryBase<WebAction>, IWebActionRepository
    {
        public WebActionRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
