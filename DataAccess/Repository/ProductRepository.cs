using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int productID) => ProductDAO.getInstance.Remove(productID);

        public Product GetProductByID(int productID) => ProductDAO.getInstance.GetProductByID(productID);

        public IEnumerable<Product> GetProducts() => ProductDAO.getInstance.GetProductList();

        public void InsertProduct(Product product) => ProductDAO.getInstance.AddNew(product);

        public IEnumerable<Product> SearchProductByNameAndID(string search) => ProductDAO.getInstance.SearchProductByNameAndID(search);
        public IEnumerable<Product> SearchProductByPrice(int price) => ProductDAO.getInstance.SearchProductByPrice(price);

        public IEnumerable<Product> SearchProductByStock(int stock) => ProductDAO.getInstance.SearchProductByStock(stock);

        public void UpdateProduct(Product product) => ProductDAO.getInstance.Update(product);
    }
}
