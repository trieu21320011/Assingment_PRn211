using BusinessObject;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();
        FStoreDBAssignmentContext DBContext = new FStoreDBAssignmentContext();


        public static OrderDAO getInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }

        public List<Order> GetOrderList() => DBContext.Orders.ToList();
        public Order GetOrderByID(int orderID) => DBContext.Orders.Find(orderID);
        public void AddNew(Order order)
        {
            if (GetOrderByID(order.OrderId) == null)
            {
                DBContext.Orders.Add(order);
                DBContext.SaveChanges();
            }
            else
            {
                throw new Exception("Order is already exists.");
            }
        }

        public void Update(Order order)
        {
            var orderUpdate = GetOrderByID(order.OrderId);
            if (orderUpdate != null)
            {
                orderUpdate.OrderId = order.OrderId;
                orderUpdate.MemberId = order.MemberId;
                orderUpdate.OrderDate = order.OrderDate;
                orderUpdate.RequiredDate = order.RequiredDate;
                orderUpdate.ShippedDate = order.ShippedDate;
                orderUpdate.Freight = order.Freight;
                DBContext.Update(orderUpdate);
                DBContext.SaveChanges();
            }
            else
            {
                throw new Exception("Product is not exist.");
            }
        }

        public void Remove(int orderID)
        {
            var product = GetOrderByID(orderID);

            DBContext.Remove(product);
            DBContext.SaveChanges();
        }

        public List<Order> SortOrderByDescending()
        {
            var orders = DBContext.Orders.ToList();

            return orders.OrderByDescending(m => m.OrderId).ToList();
        }

        public List<Order> SortOrderByDate(DateTime min, DateTime max)
        {
            if (min > max)
            {
                DateTime tmp = max;
                max = min;
                min = tmp;
            }

            var orders = DBContext.Orders.ToList();
            List<Order> newList = new List<Order>();

            foreach (var order in orders)
            {
                if (order.OrderDate >= min && order.OrderDate <= max)
                {
                    newList.Add(order);
                }
            }

            return newList.OrderByDescending(m => m.OrderDate).ToList();
        }
    } 
}
