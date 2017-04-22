using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Model;

namespace Wool.Data.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        public SupplierRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public Supplier GetSupplierByName(string supplierName)
        {
            var supplier = this.DbContext.Suppliers.Where(c => c.Name == supplierName).FirstOrDefault();
            return supplier;
        }

        public override void Update(Supplier entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
    }
}
