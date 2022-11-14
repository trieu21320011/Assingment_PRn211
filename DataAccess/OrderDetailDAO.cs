using BusinessObject;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();
        FStoreDBAssignmentContext DBContext = new FStoreDBAssignmentContext();


        public static OrderDetailDAO getInstance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                    return instance;
                }
            }
        }

        public List<OrderDetail> GetOrderDetailList(int orderId)
        {
            var orderDetails = DBContext.OrderDetails.ToList();

            List<OrderDetail> newList = new List<OrderDetail>();

            foreach (var orderD in orderDetails)
            {
                if (orderD.OrderId == orderId)
                {
                    newList.Add(orderD);
                }
            }

            return newList;
        }
        public OrderDetail GetOrderDetailById(int orderID, int productID) => DBContext.OrderDetails.Find(orderID, productID);
        public void AddNew(OrderDetail orderDetail)
        {
            if (GetOrderDetailById(orderDetail.OrderId, orderDetail.ProductId) == null)
            {
                DBContext.OrderDetails.Add(orderDetail);
                DBContext.SaveChanges();
            }
            else
            {
                Update(orderDetail);
            }
        }

        public void Update(OrderDetail orderDetail)
        {
            var orderDetailUpdate = GetOrderDetailById(orderDetail.OrderId, orderDetail.ProductId);
            if (orderDetailUpdate != null)
            {
                orderDetailUpdate.OrderId = orderDetail.OrderId;
                orderDetailUpdate.ProductId = orderDetail.ProductId;
                orderDetailUpdate.UnitPrice = orderDetail.UnitPrice;
                orderDetailUpdate.Quantity = orderDetail.Quantity;
                orderDetailUpdate.Discount = orderDetail.Discount;
                DBContext.Update(orderDetailUpdate);
                DBContext.SaveChanges();
            }
            else
            {
                throw new Exception("Product is not exist.");
            }
        }

        public void Remove(int orderID, int productId)
        {
            var orderDetail = GetOrderDetailById(orderID, productId);

            DBContext.Remove(orderDetail);
            DBContext.SaveChanges();
        }
    }
}
