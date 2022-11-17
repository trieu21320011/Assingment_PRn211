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
    public partial class frmProduct : Form
    {
        ProductRepository productRepository = new ProductRepository();

        BindingSource source;

        public bool InsertOrUpdate { get; set; }

        public Product ProductInfo { get; set; }

        public string EmailLogin { get; set; }

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadProductBySearchNameAndID(txtSearchIDName.Text);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            bool flag = true;
            int newSearch = 0;
            try
            {
                newSearch = Int32.Parse(txtQuantity.Text);
                Type checkType = newSearch.GetType();

                if (checkType.Equals(typeof(int)))
                {
                    flag = true;
                }
            }
            catch (FormatException)
            {
                flag = false;
                LoadProductList();
            }

            if (flag)
            {
                LoadProductBySearchStock(newSearch);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void ClearText()
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtCate.Text = string.Empty;
            txtStock.Text = string.Empty;
        }

        public void LoadProductList()
        {
            var products = productRepository.GetProducts();
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                txtID.DataBindings.Clear();
                txtCate.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtStock.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "ProductId");
                txtCate.DataBindings.Add("Text", source, "CategoryId");
                txtName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                dgvProductList.Columns.Remove("OrderDetails");
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

        public void LoadProductBySearchNameAndID(string search)
        {
            var products = productRepository.SearchProductByNameAndID(search);
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                txtID.DataBindings.Clear();
                txtCate.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtStock.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "ProductId");
                txtCate.DataBindings.Add("Text", source, "CategoryId");
                txtName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                dgvProductList.Columns.Remove("OrderDetails");
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

        public void LoadProductBySearchPrice(int search)
        {
            var products = productRepository.SearchProductByPrice(search);
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                txtID.DataBindings.Clear();
                txtCate.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtStock.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "ProductId");
                txtCate.DataBindings.Add("Text", source, "CategoryId");
                txtName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                dgvProductList.Columns.Remove("OrderDetails");
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

        public void LoadProductBySearchStock(int search)
        {
            var products = productRepository.SearchProductByStock(search);
            try
            {
                source = new BindingSource();
                source.DataSource = products;

                txtID.DataBindings.Clear();
                txtCate.DataBindings.Clear();
                txtName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtStock.DataBindings.Clear();

                txtID.DataBindings.Add("Text", source, "ProductId");
                txtCate.DataBindings.Add("Text", source, "CategoryId");
                txtName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProductList.DataSource = null;
                dgvProductList.DataSource = source;
                dgvProductList.Columns.Remove("OrderDetails");
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

        private Product GetProductInfo()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = Int32.Parse(txtID.Text),
                    ProductName = txtName.Text,
                    CategoryId = Int32.Parse(txtCate.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = Decimal.Parse(txtPrice.Text),
                    UnitslnStock = Int32.Parse(txtStock.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Member");
            }
            return product;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail()
            {
                Text = "Add Product",
                InsertOrUpdate = false,
                ProductRepository = productRepository
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
            else
            {
                LoadProductList();
            }
        }

        private void dgvProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail()
            {
                Text = "Product Product",
                InsertOrUpdate = true,
                ProductInfo = GetProductInfo(),
                ProductRepository = productRepository
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
            else
            {
                LoadProductList();
            }
        }

        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var product = GetProductInfo();
                DialogResult dialogResult = MessageBox.Show($"Do you want to delete product {product.ProductName} ?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    productRepository.DeleteProduct(product.ProductId);
                    LoadProductList();
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a member");
            }
        }

        private void txtSearchPrice_TextChanged(object sender, EventArgs e)
        {
            bool flag = true;
            int newSearch = 0;
            try
            {
                newSearch = Int32.Parse(txtSearchPrice.Text);
                Type checkType = newSearch.GetType();

                if (checkType.Equals(typeof(int)))
                {
                    flag = true;
                }
            }
            catch (FormatException)
            {
                flag = false;
                LoadProductList();
            }

            if (flag)
            {
                LoadProductBySearchPrice(newSearch);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
