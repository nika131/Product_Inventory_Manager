using Product_Inventory_Manager.Data;
using Product_Inventory_Manager.Repositories;
using Product_Inventory_Manager.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager.Presenters
{
    internal class ProductEntryPresenter
    {
        private readonly IProductEntryView _view;
        private readonly IProductRepository _repository;

        public ProductEntryPresenter(IProductEntryView view, IProductRepository repository)
        {
            _view = view;
            _repository = repository;
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
                _repository.upSert(
                    _view.productId, 
                    _view.productName, 
                    _view.categoryId, 
                    _view.productQuantity, 
                    _view.productPrice,
                    _view.costPrice,
                    _view.supplierId
                );

                _view.closeView();
            }catch (Exception ex)
            {
                _view.showMessage(ex.Message);
            }
        }

        public void showInitializationData(int selectedCatId = 0, int selectedSupId = 0)
        {
            try
            {
                DataTable cats = _repository.getCategories();
                DataTable sups = _repository.getSuppliers();
                
                _view.loadCategories(cats);
                _view.loadSuppliers(sups);

                if (selectedCatId > 0) _view.categoryId = selectedCatId;
                if (selectedSupId > 0) _view.supplierId = selectedSupId;
            }catch (Exception ex)
            {
                _view.showMessage("Could not load categories and supliers: " + ex.Message);
            }
        }
    }
}
