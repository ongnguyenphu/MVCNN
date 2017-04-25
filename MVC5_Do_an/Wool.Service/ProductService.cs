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
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ISupplierRepository supplierRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, ISupplierRepository supplierRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.supplierRepository = supplierRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IProductService Members

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = productRepository.GetAll();
            return products;
        }

        public IEnumerable<Product> GetProductsByCategoryName(string categoryName, string productName = null)
        {
            Category category = categoryRepository.GetCategoryByName(categoryName);
            string name = productName.ToLower().Trim();
            return category.Products.Where(p => p.Name.ToLower().Contains(name));
        }

        public IEnumerable<Product> GetProductsByCategory(long categoryId)
        {
            Category category = categoryRepository.GetById(categoryId);
            return category.Products;
        }
        public IEnumerable<Product> GetProductsBySupplier(long supplierId)
        {
            Supplier supplier = supplierRepository.GetById(supplierId);
            return supplier.Products;
        }


        public Product GetProductByID(long id)
        {
            Product product = productRepository.GetById(id);
            return product;
        }

        public void CreateProduct(Product product)
        {
            productRepository.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            productRepository.Delete(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }



        #endregion

    }
}
