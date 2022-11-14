using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void DeleteOrder(int orderID) => OrderDAO.getInstance.Remove(orderID);
        public Order GetOrderByID(int orderID) => OrderDAO.getInstance.GetOrderByID(orderID);

        public IEnumerable<Order> GetOrders() => OrderDAO.getInstance.GetOrderList();

        public void InsertOrder(Order order) => OrderDAO.getInstance.AddNew(order);

        public IEnumerable<Order> SortOrderByDate(DateTime min, DateTime max) => OrderDAO.getInstance.SortOrderByDate(min, max);

        public IEnumerable<Order> SortOrderByDescending() => OrderDAO.getInstance.SortOrderByDescending();

        public void UpdateOrder(Order order) => OrderDAO.getInstance.Update(order);
    }
}
