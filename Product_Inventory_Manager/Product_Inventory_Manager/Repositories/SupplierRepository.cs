using Product_Inventory_Manager.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager.Product_Inventory_Manager.Repositories
{
    internal class SupplierRepository : ISupplierRepository
    {
        public DataTable getAllSuppliers() => DatabaseHelper.ExecuteStoredProcedure("sp_GetSuppliers");

        public DataTable searchSuppliers(string Keyword) => 
            DatabaseHelper.ExecuteStoredProcedure("sp_SearchSuppliers", new Dictionary<string, object> { { "@Keyword", Keyword } });

        public void upsertSuppliers(int id, string companyName, string contactName, string phone, string email)
        {
            var args = new Dictionary<string, object>
            {
                { "@supplierId", id },
                { "@companyName", companyName },
                { "@contactName", contactName },
                { "@phone", phone },
                { "@email", email }
            };
            DatabaseHelper.ExecuteNonQuery("sp_UsertSupplier", args);
        }

        public void deleteSupplier(int id) =>
            DatabaseHelper.ExecuteNonQuery("sp_DeleteSupplier", new Dictionary<string, object> { { "@supplierId", id } });
    }
}
