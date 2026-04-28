using Product_Inventory_Manager.Data;
using System;
using System.Collections.Generic;

namespace Product_Inventory_Manager
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

       

        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Button btnSupplierView;
        private System.Windows.Forms.Button btnHomePage;
    }
}

