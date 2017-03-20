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
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IProductService Members

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = productRepository.GetAll();
            return products;
        }

        public IEnumerable<Product> GetCategoryProducts(string categoryName, string productName = null)
        {
            Category category = categoryRepository.GetCategoryByName(categoryName);
            string name = productName.ToLower().Trim();
            return category.Products.Where(p => p.Name.ToLower().Contains(name));
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

        public void SaveProduct()
        {
            unitOfWork.Commit();
        }



        #endregion

    }
}
