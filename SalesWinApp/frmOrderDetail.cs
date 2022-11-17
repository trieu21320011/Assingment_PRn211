using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmOrderDetail : Form
    {

        public IOrderRepository OrderRepository;
        public OrderDetailRepository OrderDetailRepository = new OrderDetailRepository();
        MemberRepository MemberRepository = new MemberRepository();
        public Boolean InsertOrUpdate { get; set; }
        public Order OrderInfo { get; set; }

        BindingSource source;

        public frmOrderDetail()
        {
            InitializeComponent();
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            var members = MemberRepository.GetMembers();


            foreach (var member in members)
            {
                cmbMember.Items.Add(member.MemberId);
                cmbMember.SelectedItem = member.MemberId;

            }

            if (InsertOrUpdate == true)
            {
                txtId.Text = OrderInfo.OrderId.ToString();
                txtId.ReadOnly = true;
                btnCancel.Enabled = false;
                btnCancel.Visible = false;

                dtpOrder.Value = OrderInfo.OrderDate;
                if (OrderInfo.RequiredDate.HasValue)
                {
                    dtpRequire.Value = OrderInfo.RequiredDate.Value;
                }
                if (OrderInfo.ShippedDate.HasValue)
                {
                    dtpShipped.Value = OrderInfo.ShippedDate.Value;
                }

                txtFreight.Text = OrderInfo.Freight.ToString();
            }
            else
            {
                dgvDetail.Enabled = false;
                btnAdd.Enabled = false;
            }
            LoadDetailList();
        }

        private OrderDetail GetOrderDetailInfo()
        {
            OrderDetail orderDetail = null;
            try
            {
                orderDetail = new OrderDetail
                {
                    OrderId = Int32.Parse(txtOrderID.Text),
                    ProductId = Int32.Parse(txtProductId.Text),
                    UnitPrice = Decimal.Parse(txtPrice.Text),
                    Quantity = Int32.Parse(txtQuantity.Text),
                    Discount = Int32.Parse(txtDiscount.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Order Detail");
            }
            return orderDetail;
        }

        private void LoadDetailList()
        {
            int id = -1;
            try
            {
                id = Int32.Parse(txtId.Text);
            }
            catch (FormatException)
            {
                id = -1;
            }

            var products = new List<OrderDetail>();
            if (id != -1)
            {
                products = (List<OrderDetail>)OrderDetailRepository.GetOrderDetails(id);
            }
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                txtOrderID.DataBindings.Clear();
                txtProductId.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtQuantity.DataBindings.Clear();
                txtDiscount.DataBindings.Clear();

                txtOrderID.DataBindings.Add("Text", source, "OrderId");
                txtProductId.DataBindings.Add("Text", source, "ProductId");
                txtPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtQuantity.DataBindings.Add("Text", source, "Quantity");
                txtDiscount.DataBindings.Add("Text", source, "Discount");

                dgvDetail.DataSource = null;
                dgvDetail.DataSource = source;
                dgvDetail.Columns.Remove("Order");
                dgvDetail.Columns.Remove("Product");
                if (products.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product List");
            }
        }

        private void ClearText()
        {
            txtOrderID.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtDiscount.Text = string.Empty;
        }
        private void checkInput(string orderID,DateTime orderDate, DateTime requiredDate, DateTime shippedDate, string freight)
        {
            var isInt = int.TryParse(orderID, out _);
           
            if(orderID.Length == 0)
            {
                throw new Exception("OrderID can not null");
           
            }
            if(isInt == false)
            {
                throw new Exception("OrderID must be Int type");
            }
            if (DateTime.Compare(requiredDate, orderDate) < 0)
            {
                throw new Exception("Required date must be later than order date");
            }
            if (DateTime.Compare(shippedDate, requiredDate) < 0)
            {
                throw new Exception("Shipped date must be later than required date");

            }
            if (freight.Length == 0)
            {
                throw new Exception("Freight can not null");

            }
            var isDecimal = decimal.TryParse(freight, out _);
            if (isDecimal == false)
            {
                throw new Exception("Freight must be a decimal");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                checkInput(txtId.Text, dtpOrder.Value, dtpRequire.Value, dtpShipped.Value, txtFreight.Text);
                var order = new Order
                {
                    OrderId = Int32.Parse(txtId.Text),
                    MemberId = Int32.Parse(cmbMember.SelectedItem.ToString().Trim()),
                    OrderDate = dtpOrder.Value,
                    RequiredDate = dtpRequire.Value,
                    ShippedDate = dtpShipped.Value,
                    Freight = Decimal.Parse(txtFreight.Text)
                };
                if (InsertOrUpdate == false)
                {
                    OrderRepository.InsertOrder(order);
                    Close();
                }
                else
                {
                    OrderRepository.UpdateOrder(order);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new product" : "Update a product");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOrderDetailProcess frmOrderDetailProcess = new frmOrderDetailProcess()
            {
                Text = "Add Order Detail",
                InsertOrUpdate = false,
                OrderId = Int32.Parse(txtId.Text),
                OrderDetailRepository = OrderDetailRepository
            };
            if (frmOrderDetailProcess.ShowDialog() == DialogResult.OK)
            {
                this.Close();
                LoadDetailList();
                source.Position = source.Count - 1;
            }
            else
            {
                LoadDetailList();
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderDetailProcess frmOrderDetailProcess = new frmOrderDetailProcess()
            {
                Text = "Add Order Detail",
                InsertOrUpdate = true,
                OrderId = Int32.Parse(txtId.Text),
                OrderDetailInfo = GetOrderDetailInfo(),
                OrderDetailRepository = OrderDetailRepository
            };
            if (frmOrderDetailProcess.ShowDialog() == DialogResult.OK)
            {
                LoadDetailList();
                source.Position = source.Count - 1;
            }
            else
            {
                LoadDetailList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var orderDetail = GetOrderDetailInfo();
                DialogResult dialogResult = MessageBox.Show($"Do you want to delete this ?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    OrderDetailRepository.DeleteOrderDetail(orderDetail.OrderId, orderDetail.ProductId);
                    LoadDetailList();
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a order detail");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
