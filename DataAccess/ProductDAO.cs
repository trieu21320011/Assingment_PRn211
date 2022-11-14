using BusinessObject;
using DataLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        FStoreDBAssignmentContext DBContext = new FStoreDBAssignmentContext();

        public static ProductDAO getInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }


        public List<Product> GetProductList() => DBContext.Products.ToList();

        public Product GetProductByID(int productID) => DBContext.Products.Find(productID);

        public void AddNew(Product product)
        {
            if (GetProductByID(product.ProductId) == null)
            {
                DBContext.Products.Add(product);
                DBContext.SaveChanges();
            }
            else
            {
                throw new Exception("Product is already exists.");
            }
        }

        public void Update(Product product)
        {
            var productUpdate = GetProductByID(product.ProductId);
            if (productUpdate != null)
            {
                productUpdate.ProductId = product.ProductId;
                productUpdate.CategoryId = product.CategoryId;
                productUpdate.UnitPrice = product.UnitPrice;
                productUpdate.ProductName = product.ProductName;
                productUpdate.UnitslnStock = product.UnitslnStock;
                productUpdate.Weight = product.Weight;
                DBContext.Update(productUpdate);
                DBContext.SaveChanges();
            }
            else
            {
                throw new Exception("Product is not exist.");
            }
        }

        public void Remove(int productID)
        {
            var product = GetProductByID(productID);

            DBContext.Remove(product);
            DBContext.SaveChanges();
        }

        public List<Product> SearchProductByNameAndID(string search)
        {
            bool flag = false;
            var products = DBContext.Products.ToList();
            List<Product> newProductList = new List<Product>();

            try
            {
                int newSearch = Int32.Parse(search);
                Type checkType = newSearch.GetType();

                if (checkType.Equals(typeof(int)))
                {
                    flag = true;
                }
            }
            catch (FormatException)
            {
                flag = false;
            }

            foreach (var product in products)
            {
                if (flag == true)
                {
                    if (product.ProductName.Contains(search) || product.ProductId == Int32.Parse(search))
                    {
                        newProductList.Add(product);
                    }
                }
                else
                {
                    if (product.ProductName.Contains(search))
                    {
                        newProductList.Add(product);
                    }
                }
            }
            return newProductList;
        }

        public List<Product> SearchProductByPrice(int price)
        {
            var products = DBContext.Products.ToList();
            List<Product> newProductList = new List<Product>();

            foreach (var product in products)
            {
                if (product.UnitPrice == price)
                {
                    newProductList.Add(product);
                }
            }
            return newProductList;
        }

        public List<Product> SearchProductByStock(int stock)
        {
            var products = DBContext.Products.ToList();
            List<Product> newProductList = new List<Product>();

            foreach (var product in products)
            {
                if (product.UnitslnStock == stock)
                {
                    newProductList.Add(product);
                }
            }
            return newProductList;
        }

    }
}
