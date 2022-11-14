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
    public partial class frmOrderDetailProcess : Form
    {

        public OrderDetailRepository OrderDetailRepository;

        ProductRepository ProductRepository = new ProductRepository();

        public int OrderId { get; set; }
        public Boolean InsertOrUpdate { get; set; }
        public OrderDetail OrderDetailInfo { get; set; }

        public frmOrderDetailProcess()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmOrderDetailProcess_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)
            {
                txtId.Text = OrderDetailInfo.OrderId.ToString();
                txtId.ReadOnly = true;
                var products = ProductRepository.GetProducts();

                cmbProduct.DataSource = products.ToList();
                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember = "ProductId";

                cmbProduct.SelectedIndex = 0;
                cmbProduct.Enabled = false;

                txtPrice.Text = OrderDetailInfo.UnitPrice.ToString();
                txtQuantity.Text = OrderDetailInfo.Quantity.ToString();
                txtDiscount.Text = OrderDetailInfo.Discount.ToString();

            }
            else
            {
                var products = ProductRepository.GetProducts();

                cmbProduct.DataSource = products.ToList();
                cmbProduct.DisplayMember = "ProductName";
                cmbProduct.ValueMember = "ProductId";
                /* foreach (var product in products)
                {
                    cmbProduct.Items.Add(new { Text = product.ProductName, Value = product.ProductId });
                    cmbProduct.SelectedItem = product.ProductId;

                } */
                cmbProduct.SelectedIndex = 0;
                txtId.Text = OrderId.ToString(); 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = Int32.Parse(txtId.Text),
                    ProductId = Int32.Parse(cmbProduct.SelectedValue.ToString().Trim()),
                    UnitPrice = Decimal.Parse(txtPrice.Text),
                    Quantity = Int32.Parse(txtQuantity.Text),
                    Discount = Int32.Parse(txtDiscount.Text)
                };
                if (InsertOrUpdate == false)
                {
                    OrderDetailRepository.InsertOrderDetail(orderDetail);
                    Close();
                }
                else
                {
                    OrderDetailRepository.UpdateOrderDetail(orderDetail);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new product" : "Update a product");
            }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
