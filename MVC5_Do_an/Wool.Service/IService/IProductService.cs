using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategoryName(string categoryName, string productName = null);
        Product GetProductByID(long id);

        IEnumerable<Product> GetProductsByCategory(long categoryId);
        IEnumerable<Product> GetProductsBySupplier(long supplierId);

        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        void SaveProduct();
    }
}
