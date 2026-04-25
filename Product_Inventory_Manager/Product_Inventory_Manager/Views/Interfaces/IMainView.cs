using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager.Views.Interfaces
{
    public interface IMainView
    {
        DataTable gridDataSource { set; }

        string totalItemsText { set; }
        string totalValueText { set; }
        string lowStockText { set; }
        Color lowStockColor { set; }

        void showError(string message);
        bool confirmDelete(string productName);
    }
}
