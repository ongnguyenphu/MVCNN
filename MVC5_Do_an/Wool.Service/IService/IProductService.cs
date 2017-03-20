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
        IEnumerable<Product> GetCategoryProducts(string categoryName, string productName = null);
        Product GetProductByID(long id);
        void CreateProduct(Product product);
        void SaveProduct();
    }
}
