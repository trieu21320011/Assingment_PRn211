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
    public partial class frmOrder : Form
    {
        OrderRepository orderRepository = new OrderRepository();
        MemberRepository memberRepository = new MemberRepository();

        BindingSource source;

        public string EmailLogin { get; set; }

        public bool InsertOrUpdate { get; set; }

        public Order OrderInfo { get; set; }

        public frmOrder()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            if (!EmailLogin.Equals("admin@fstore.com"))
            {
                LoadOrderListDetail();
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;               
                dtpMax.Enabled = false;
                dtpMin.Enabled = false;
            }
            else
            {
                LoadOrderList();
            }

        }

        private void ClearText()
        {
            txtID.Text = string.Empty;
            txtMemberID.Text = string.Empty;
            txtFreight.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtRequiredDate.Text = string.Empty;
            txtShipDate.Text = string.Empty;
        }

        public void LoadOrderList()
        {
            var orders = orderRepository.GetOrders();
            try
            {
                source = new BindingSource();
                source.DataSource = orders;

                txtID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShipDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "OrderId");
                txtMemberID.DataBindings.Add("Text", source, "MemberId");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShipDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dgvOrderList.DataSource = null;
                dgvOrderList.DataSource = source;
                dgvOrderList.Columns.Remove("Member");
                dgvOrderList.Columns.Remove("OrderDetails");
                if (orders.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load order List");
            }
        }

        public void LoadOrderListDetail()
        {
            List<Order> getOrders = (List<Order>)orderRepository.GetOrders();
            Member mem = memberRepository.GetMemberByEmail(EmailLogin);
            List<Order> orders = getOrders.FindAll(o => o.MemberId.Equals(mem.MemberId));
            try
            {
                source = new BindingSource();
                source.DataSource = orders;

                txtID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShipDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "OrderId");
                txtMemberID.DataBindings.Add("Text", source, "MemberId");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShipDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dgvOrderList.DataSource = null;
                dgvOrderList.DataSource = source;
                dgvOrderList.Columns.Remove("Member");
                dgvOrderList.Columns.Remove("OrderDetails");
                if (orders.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load order List");
            }
        }

        public void LoadOrderListBySort()
        {
            var orders = orderRepository.SortOrderByDescending();
            try
            {
                source = new BindingSource();
                source.DataSource = orders;

                txtID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShipDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "OrderId");
                txtMemberID.DataBindings.Add("Text", source, "MemberId");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShipDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dgvOrderList.DataSource = null;
                dgvOrderList.DataSource = source;
                dgvOrderList.Columns.Remove("Member");
                dgvOrderList.Columns.Remove("OrderDetails");
                if (orders.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load order List");
            }
        }

        private Order GetOrderInfo()
        {
            Order order = null;
            try
            {
                order = new Order
                {
                    OrderId = Int32.Parse(txtID.Text),
                    MemberId = Int32.Parse(txtMemberID.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShipDate.Text),
                    Freight = Decimal.Parse(txtFreight.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Order");
            }
            return order;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail()
            {
                Text = "Add Order",
                InsertOrUpdate = false,
                OrderRepository = orderRepository
            };
            if (frmOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }
            else
            {
                LoadOrderList();
            }
        }

        private void dgvOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail()
            {
                Text = "Order",
                InsertOrUpdate = true,
                OrderInfo = GetOrderInfo(),
                OrderRepository = orderRepository,
                EmailLogin = EmailLogin
            };
            if (frmOrderDetail.ShowDialog() == DialogResult.OK)
            {
                LoadOrderList();
                source.Position = source.Count - 1;
            }
            else
            {
                LoadOrderList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var order = GetOrderInfo();
                DialogResult dialogResult = MessageBox.Show($"Do you want to delete order {order.OrderId} ?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    orderRepository.DeleteOrder(order.OrderId);
                    LoadOrderList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }

        public void LoadOrderListByDate()
        {
            var orders = orderRepository.SortOrderByDate(dtpMin.Value, dtpMax.Value);
            try
            {
                source = new BindingSource();
                source.DataSource = orders;

                txtID.DataBindings.Clear();
                txtMemberID.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShipDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "OrderId");
                txtMemberID.DataBindings.Add("Text", source, "MemberId");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShipDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dgvOrderList.DataSource = null;
                dgvOrderList.DataSource = source;
                dgvOrderList.Columns.Remove("Member");
                dgvOrderList.Columns.Remove("OrderDetails");
                if (orders.Count() == 0)
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
                MessageBox.Show(ex.Message, "Load order List");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (EmailLogin.Equals("admin@fstore.com"))
            {
                LoadOrderListByDate();
            }
        }

        private void dtpMax_ValueChanged(object sender, EventArgs e)
        {
            if (EmailLogin.Equals("admin@fstore.com"))
            {
                LoadOrderListByDate();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            if (!EmailLogin.Equals("admin@fstore.com"))
            {
                LoadOrderListDetail();
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                dtpMax.Enabled = false;
                dtpMin.Enabled = false;
            }
            else
            {
                LoadOrderList();
            }
        }

        private void dgvOrderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
