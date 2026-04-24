using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager
{
    internal interface IProductRepository
    {
        DataTable getAll();
        DataTable search(string keyword);
        void upSert(int id, string name, int catId, int qty, decimal price);
        void delete(int id);
        DataTable getCategories();
    }
}
