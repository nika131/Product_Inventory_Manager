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
    public partial class ProductEntryForm : Form 
    {
        public string productName { get => txtName.Text; set => txtName.Text = value; }
        public decimal productPrice { get => numPrice.Value; set => numPrice.Value = value; }
        public int productQuantity { get => (int)numQuantity.Value; set => numQuantity.Value = value; }
        public int caregoryId { get => (int)cbCategory.SelectedValue; set => cbCategory.SelectedValue = value; }
        public int productId { get; set; } = 0;
        public ProductEntryForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var args = new Dictionary<string, object>
            {
                { "@id", this.productId  },
                { "@name", txtName.Text },
                { "@catId", cbCategory.SelectedValue },
                { "@qty", numQuantity.Value },
                { "@price", numPrice.Value },
            };

            DatabaseHelper.ExecuteNonQuery("sp_upsertProduct", args);
            this.DialogResult = DialogResult.OK;
        }

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
    }
}
