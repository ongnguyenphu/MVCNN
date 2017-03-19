using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        WoolEntities dbContext;

        public WoolEntities Init()
        {
            return dbContext ?? (dbContext = new WoolEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
