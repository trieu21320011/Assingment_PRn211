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
        private void checkInput(string orderID, string unitPrice, string quantity, string discount)
        {
            var isInt = int.TryParse(orderID, out _);

            if (orderID.Length == 0)
            {
                throw new Exception("OrderID can not null");

            }
            
            if (isInt == false)
            {
                throw new Exception("OrderID must be Int type");
            }
            if (unitPrice.Length == 0)
            {
                throw new Exception("Unit pricew can not null");

            }
            var isDecimal = decimal.TryParse(unitPrice, out _);
            if (isDecimal == false)
            {
                throw new Exception("Unit price must be a decimal");
            }
            isInt = int.TryParse(quantity, out _);
            if (quantity.Length == 0)
            {
                throw new Exception("Quantity can not null");

            }
            if (isInt == false)
            {
                throw new Exception("Quantity must be Int type");
            }
            var isDouble = double.TryParse(discount, out _);

            if (discount.Length == 0)
            {
                throw new Exception("Discount can not null");

            }
            if (isDouble == false)
            {
                throw new Exception("Discount must be double type");
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                checkInput(txtId.Text, txtPrice.Text, txtQuantity.Text, txtDiscount.Text);
                var orderDetail = new OrderDetail
                {
                    OrderId = Int32.Parse(txtId.Text),
                    ProductId = Int32.Parse(cmbProduct.SelectedValue.ToString().Trim()),
                    UnitPrice = Decimal.Parse(txtPrice.Text),
                    Quantity = Int32.Parse(txtQuantity.Text),
                    Discount = Double.Parse(txtDiscount.Text)
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

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
