using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager.Product_Inventory_Manager.Repositories
{
    internal interface ISupplierRepository
    {
        DataTable getAllSuppliers();
        DataTable searchSuppliers(string Keyword);
        void upsertSuppliers(int id, string companyName, string contactName, string phone, string email);
        void deleteSupplier(int id);

    }
}
