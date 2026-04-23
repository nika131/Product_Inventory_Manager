using Product_Inventory_Manager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager
{
    internal class ProductEntryPresenter
    {
        private readonly IProductEntryView _view;

        public ProductEntryPresenter(IProductEntryView view)
        {
            _view = view;
        }

        public void saveProduct()
        {
            if (string.IsNullOrWhiteSpace(_view.productName))
            {
                _view.showMessage("Product Name is Required");
                return;
            }

            if (_view.categoryId <= 0)
            {
                _view.showMessage("Please select a category.");
                return;
            }

            if (_view.productPrice <= 0)
            {
                _view.showMessage("Price must be greater than zero.");
                return;
            }

            try
            {
                var args = new Dictionary<string, object>
                {
                    {"@id", _view.productId },
                    { "@name", _view.productName },
                    { "@catId", _view.categoryId },
                    { "@qty", _view.productQuantity },
                    { "@price", _view.productPrice },
                };

                DatabaseHelper.ExecuteNonQuery("sp_UpsertProduct", args);
                _view.closeView();
            }catch (Exception ex)
            {
                _view.showMessage(ex.Message);
            }
        }
    }
}
