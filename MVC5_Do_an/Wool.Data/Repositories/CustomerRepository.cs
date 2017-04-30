using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Model;

namespace Wool.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public Customer GetByName(string name)
        {
            var customer = this.DbContext.Customers.Where(c => c.Username == name).FirstOrDefault();
            return customer;
        }
    }
}
