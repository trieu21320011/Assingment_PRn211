
namespace SalesWinApp
{
    partial class frmProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearchIDName = new System.Windows.Forms.TextBox();
            this.txtSearchPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCate = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchIDName
            // 
            this.txtSearchIDName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSearchIDName.Location = new System.Drawing.Point(12, 96);
            this.txtSearchIDName.Name = "txtSearchIDName";
            this.txtSearchIDName.PlaceholderText = "Enter product ID or name to search";
            this.txtSearchIDName.Size = new System.Drawing.Size(320, 23);
            this.txtSearchIDName.TabIndex = 1;
            this.txtSearchIDName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtSearchPrice
            // 
            this.txtSearchPrice.Location = new System.Drawing.Point(338, 96);
            this.txtSearchPrice.Name = "txtSearchPrice";
            this.txtSearchPrice.PlaceholderText = "Enter product price to search";
            this.txtSearchPrice.Size = new System.Drawing.Size(184, 23);
            this.txtSearchPrice.TabIndex = 2;
            this.txtSearchPrice.TextChanged += new System.EventHandler(this.txtSearchPrice_TextChanged);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(528, 96);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PlaceholderText = "Enter product quantity to search";
            this.txtQuantity.Size = new System.Drawing.Size(199, 23);
            this.txtQuantity.TabIndex = 6;
            this.txtQuantity.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // dgvProductList
            // 
            this.dgvProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Location = new System.Drawing.Point(12, 151);
            this.dgvProductList.MultiSelect = false;
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.ReadOnly = true;
            this.dgvProductList.RowTemplate.Height = 25;
            this.dgvProductList.Size = new System.Drawing.Size(715, 334);
            this.dgvProductList.TabIndex = 7;
            this.dgvProductList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellContentClick);
            this.dgvProductList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellDoubleClick);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(743, 151);
            this.btnLoadData.MinimumSize = new System.Drawing.Size(100, 0);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(145, 31);
            this.btnLoadData.TabIndex = 10;
            this.btnLoadData.Text = "Refresh Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(745, 454);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(145, 31);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(743, 232);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(145, 31);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add Product";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(745, 269);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(145, 31);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete Product";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 32);
            this.label1.TabIndex = 14;
            this.label1.Text = "FStore Management";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(338, 28);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(0, 23);
            this.txtID.TabIndex = 15;
            // 
            // txtCate
            // 
            this.txtCate.Location = new System.Drawing.Point(444, 28);
            this.txtCate.Name = "txtCate";
            this.txtCate.Size = new System.Drawing.Size(0, 23);
            this.txtCate.TabIndex = 16;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(550, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(0, 23);
            this.txtName.TabIndex = 17;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(656, 28);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(0, 23);
            this.txtWeight.TabIndex = 18;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(338, 57);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(0, 23);
            this.txtPrice.TabIndex = 19;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(444, 57);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(0, 23);
            this.txtStock.TabIndex = 20;
            // 
            // frmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 497);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCate);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.dgvProductList);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtSearchPrice);
            this.Controls.Add(this.txtSearchIDName);
            this.Name = "frmProduct";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtSearchIDName;
        public System.Windows.Forms.TextBox txtSearchPrice;
        public System.Windows.Forms.TextBox txtQuantity;
        public System.Windows.Forms.TextBox txtCate;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtWeight;
        public System.Windows.Forms.TextBox txtStock;
        public System.Windows.Forms.TextBox txtID;
        public System.Windows.Forms.TextBox txtPrice;
    }
}