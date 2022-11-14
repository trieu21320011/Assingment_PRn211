using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(int orderID);
        void InsertOrder(Order order);
        void DeleteOrder(int orderID);
        void UpdateOrder(Order order);
        IEnumerable<Order> SortOrderByDescending();
        IEnumerable<Order> SortOrderByDate(DateTime min, DateTime max);
    }
}
