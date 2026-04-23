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
    public partial class ProductEntryForm : Form, IProductEntryView
    {
        private ProductEntryPresenter _presenter;

        public ProductEntryForm()
        {
            InitializeComponent();
            _presenter = new ProductEntryPresenter(this);
        }


        public string productName { get => txtName.Text; set => txtName.Text = value; }
        public decimal productPrice { get => numPrice.Value; set => numPrice.Value = value; }
        public int productQuantity { get => (int)numQuantity.Value; set => numQuantity.Value = value; }
        public int categoryId
        {
            get => cbCategory.SelectedValue != null ? (int)cbCategory.SelectedValue : 0;
            set => cbCategory.SelectedValue = value;
        }
        public int productId { get; set; } = 0;


        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.saveProduct();
        }

        public void showMessage(string message) => MessageBox.Show(message);
        public void closeView() => this.DialogResult = DialogResult.OK;

        private void ProductEntryForm_Load(object sender, EventArgs e)
        {
            DataTable dt = DatabaseHelper.ExecuteStoredProcedure("sp_GetCategories");

            cbCategory.DataSource = dt;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryId";
        }

        private void numPrice_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
