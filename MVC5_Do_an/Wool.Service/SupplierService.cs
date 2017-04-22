using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Data.Repositories;
using Wool.Model;

namespace Wool.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IUnitOfWork unitOfWork;

        public SupplierService(ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            this.supplierRepository = supplierRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ISupplierService Members

        public IEnumerable<Supplier> GetSuppliers(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return supplierRepository.GetAll();
            else
                return supplierRepository.GetAll().Where(c => c.Name == name);
        }

        public Supplier GetSupplierByID(long id)
        {
            Supplier supplier = supplierRepository.GetById(id);
            return supplier;
        }

        public Supplier GetSupplierByName(string name)
        {
            Supplier supplier = supplierRepository.GetSupplierByName(name);
            return supplier;
        }

        public void CreateSupplier(Supplier supplier)
        {
            supplierRepository.Add(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            supplierRepository.Delete(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            supplierRepository.Update(supplier);
        }

        public void SaveSupplier()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}
