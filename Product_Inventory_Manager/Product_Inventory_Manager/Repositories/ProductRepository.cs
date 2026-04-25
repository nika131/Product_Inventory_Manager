using Product_Inventory_Manager.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product_Inventory_Manager.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        public DataTable getAll() => DatabaseHelper.ExecuteStoredProcedure("sp_GetAllProducts");

        public DataTable search(string keyword) =>
            DatabaseHelper.ExecuteStoredProcedure("sp_SearchProducts", new Dictionary<string, object> { { "@Keyword", keyword } });

        public void upSert(int id, string name, int catId, int qty, decimal price)
        {
            var args = new Dictionary<string, object>
            {
                { "@id", id }, { "@name", name}, { "@catId", catId }, { "@qty", qty }, { "@price", price } 
            };
            DatabaseHelper.ExecuteNonQuery("sp_UpsertProduct", args);
        }

        public void delete(int id) =>
            DatabaseHelper.ExecuteNonQuery("sp_DeleteProduct", new Dictionary<string, object> { { "@productId", id } });

        public DataTable getCategories() => DatabaseHelper.ExecuteStoredProcedure("sp_GetCategories");

    }
}
