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
    public partial class frmProductDetail : Form
    {

        public IProductRepository ProductRepository;
        public Boolean InsertOrUpdate { get; set; }
        public Product ProductInfo { get; set; }

        public frmProductDetail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmProductDetail_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)
            {
                txtID.Text = ProductInfo.ProductId.ToString();
                txtID.ReadOnly = true;
                txtCate.Text = ProductInfo.CategoryId.ToString();
                txtPrice.Text = ProductInfo.UnitPrice.ToString();
                txtStock.Text = ProductInfo.UnitslnStock.ToString();
                txtName.Text = ProductInfo.ProductName.ToString();
                txtWeight.Text = ProductInfo.Weight.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(txtName.Text.Trim()) ||
                    String.IsNullOrEmpty(txtWeight.Text.Trim()))
                   
                {
                    throw new Exception("Fields can't empty!");
                }
                var product = new Product
                {
                    ProductId = Int32.Parse(txtID.Text),
                    ProductName = txtName.Text,
                    CategoryId = Int32.Parse(txtCate.Text),
                    UnitPrice = Decimal.Parse(txtPrice.Text),
                    Weight = txtWeight.Text,
                    UnitslnStock = Int32.Parse(txtStock.Text)
                };
                if (InsertOrUpdate == false)
                {
                    ProductRepository.InsertProduct(product);
                    Close();
                }
                else
                {
                    ProductRepository.UpdateProduct(product);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new product" : "Update a product");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
