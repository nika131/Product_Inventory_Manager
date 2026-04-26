using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager.Product_Inventory_Manager.Views.Interfaces
{
    internal interface ISupplierView
    {
        DataTable SupplierGridDataSource { set; }
        int supplierId { get; }
        string companyName { get; }
        string contactName { get; }
        string phone { get; }
        string email { get; }
    
        void showMessage(string message);
    }
}
