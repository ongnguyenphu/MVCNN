using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Model;

namespace Wool.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByName(string name);
    }
}
