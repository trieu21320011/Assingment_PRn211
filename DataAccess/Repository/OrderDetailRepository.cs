using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public OrderDetailRepository() { }

        public void DeleteOrderDetail(int orderDetailID, int productId) => OrderDetailDAO.getInstance.Remove(orderDetailID, productId);

        public OrderDetail GetOrderDetailByID(int orderDetailID, int productId) => OrderDetailDAO.getInstance.GetOrderDetailById(orderDetailID, productId);

        public OrderDetail GetOrderDetailByID(int orderDetailID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetail> GetOrderDetails(int orderId) => OrderDetailDAO.getInstance.GetOrderDetailList(orderId);

        public void InsertOrderDetail(OrderDetail OrderDetail) => OrderDetailDAO.getInstance.AddNew(OrderDetail);

        public void UpdateOrderDetail(OrderDetail OrderDetail) => OrderDetailDAO.getInstance.Update(OrderDetail);
    }
}
