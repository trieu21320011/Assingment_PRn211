using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails(int orderId);
        OrderDetail GetOrderDetailByID(int orderDetailID);
        void InsertOrderDetail(OrderDetail OrderDetail);
        void DeleteOrderDetail(int orderDetaulID, int productId);
        void UpdateOrderDetail(OrderDetail OrderDetail);
    }
}
