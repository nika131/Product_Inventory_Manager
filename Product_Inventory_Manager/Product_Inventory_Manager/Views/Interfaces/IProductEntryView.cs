using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager.Views.Interfaces
{
    public interface IProductEntryView
    {
        int productId { get; set; }
        string productName { get; set; }
        decimal productPrice { get; set; }
        int productQuantity { get; set; }
        int categoryId { get; set; }
        int initialCategoryId { get; set; }

        void showMessage(string message);
        void closeView();
        void loadCategories(DataTable categories);
    }
}
