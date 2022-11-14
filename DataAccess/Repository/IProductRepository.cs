using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int productID);
        void InsertProduct(Product product);
        void DeleteProduct(int productID);
        void UpdateProduct(Product product);

        IEnumerable<Product> SearchProductByNameAndID(string search);
        IEnumerable<Product> SearchProductByPrice(int price);
        IEnumerable<Product> SearchProductByStock(int stock);
    }
}
