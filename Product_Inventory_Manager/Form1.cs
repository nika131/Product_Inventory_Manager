using Product_Inventory_Manager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Inventory_Manager
{
    public partial class Form1 : Form, IMainView
    {
        private MainPresenter _presenter;
        public Form1()
        {
            InitializeComponent();
            _presenter = new MainPresenter(this);
            _presenter.refreshData();
            this.dgvProducts.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvProducts_CellFormatting);
        }

        public DataTable gridDataSource { set => dgvProducts.DataSource = value; }
        public string totalItemsText { set => lblTotalItems.Text = value; }
        public string totalValueText { set => lblTotalValue.Text = value; }
        public string lowStockText { set => lblLowStock.Text = value; }
        public Color lowStockColor { set => lblLowStock.ForeColor = value; }

        public void showError(string message) => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        
        
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            _presenter.search(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var Form = new ProductEntryForm())
            {
                Form.productId = 0;
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    _presenter.refreshData();
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                using (var form = new ProductEntryForm())
                {
                    var row = dgvProducts.CurrentRow;

                    form.productId = (int)row.Cells["ProductId"].Value;
                    form.productName = row.Cells["ProductName"].Value.ToString();
                    form.productPrice = (decimal)row.Cells["ProductPrice"].Value;
                    form.productQuantity = (int)row.Cells["Quantity"].Value;
                    form.categoryId = (int)row.Cells["CategoryId"].Value;

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        _presenter.refreshData();

                    }
                }
            }
        }
        public bool confirmDelete(string productName)
        {
            return MessageBox.Show($"Are you sure you want to delete {productName}?",
                "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                int id = (int)dgvProducts.CurrentRow.Cells["ProductId"].Value;
                string name = dgvProducts.CurrentRow.Cells["ProductName"].Value.ToString();
                _presenter.deleteProduct(id, name);
            }
        }


        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Quantity" && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int qty))
                {
                    if (qty < 5)
                    {
                        e.CellStyle.BackColor = Color.Salmon;
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.SelectionBackColor = Color.DarkRed;
                    }
                    else
                    {
                        e.CellStyle.BackColor = dgvProducts.DefaultCellStyle.BackColor;
                        e.CellStyle.ForeColor = dgvProducts.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }




        private void InitializeComponent()
        {
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.ProductName,
            this.Category,
            this.CategoryId,
            this.ProductPrice,
            this.Quantity});
            this.dgvProducts.Location = new System.Drawing.Point(12, 36);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.Size = new System.Drawing.Size(802, 408);
            this.dgvProducts.TabIndex = 0;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.MinimumWidth = 6;
            this.ProductId.Name = "ProductId";
            this.ProductId.Width = 125;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 125;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            this.Category.Width = 125;
            // 
            // CategoryId
            // 
            this.CategoryId.DataPropertyName = "CategoryId";
            this.CategoryId.HeaderText = "CategoryId";
            this.CategoryId.MinimumWidth = 6;
            this.CategoryId.Name = "CategoryId";
            this.CategoryId.Width = 125;
            // 
            // ProductPrice
            // 
            this.ProductPrice.DataPropertyName = "ProductPrice";
            this.ProductPrice.HeaderText = "ProductPrice";
            this.ProductPrice.MinimumWidth = 6;
            this.ProductPrice.Name = "ProductPrice";
            this.ProductPrice.Width = 125;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.Width = 125;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(838, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(208, 22);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(838, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(962, 95);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(117, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(838, 141);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(838, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "search product";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Location = new System.Drawing.Point(26, 520);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(44, 16);
            this.lblTotalItems.TabIndex = 7;
            this.lblTotalItems.Text = "label2";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Location = new System.Drawing.Point(183, 520);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(44, 16);
            this.lblTotalValue.TabIndex = 8;
            this.lblTotalValue.Text = "label3";
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Location = new System.Drawing.Point(357, 520);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(44, 16);
            this.lblLowStock.TabIndex = 9;
            this.lblLowStock.Text = "label4";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1091, 671);
            this.Controls.Add(this.lblLowStock);
            this.Controls.Add(this.lblTotalValue);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvProducts);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
