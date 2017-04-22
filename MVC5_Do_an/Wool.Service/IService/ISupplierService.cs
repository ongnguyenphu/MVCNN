using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Service
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetSuppliers(string name = null);
        Supplier GetSupplierByID(long id);
        Supplier GetSupplierByName(string name);
        void CreateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);

        void SaveSupplier();
    }
}
