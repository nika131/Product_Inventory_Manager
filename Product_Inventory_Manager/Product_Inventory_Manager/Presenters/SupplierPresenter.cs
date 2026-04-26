using Product_Inventory_Manager.Product_Inventory_Manager.Repositories;
using Product_Inventory_Manager.Product_Inventory_Manager.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory_Manager.Product_Inventory_Manager.Presenters
{
    internal class SupplierPresenter
    {
        private readonly ISupplierView _view;
        private readonly ISupplierRepository _repository;

        public SupplierPresenter(ISupplierView view, ISupplierRepository repository)
        {
            _view = view;
            _repository = repository;
        }

        public void refreshData()
        {
            try
            {
                DataTable dt = _repository.getAllSuppliers();
                _view.SupplierGridDataSource = dt;
            }
            catch (Exception ex)
            {
                _view.showMessage(ex.Message);
            }
        }

        public void searchSuppliers(string keyword)
        {
            try
            {
                DataTable dt = _repository.searchSuppliers(keyword);
                _view.SupplierGridDataSource = dt;
            }
            catch (Exception ex)
            {
                _view.showMessage(ex.Message);
            }
        }
        public void saveSupplier()
        {
            if (string.IsNullOrEmpty(_view.companyName))
            {
                _view.showMessage("Company Name is Required");
                return;
            }
            try
            {
                _repository.upsertSuppliers(
                    _view.supplierId,
                    _view.companyName,
                    _view.contactName,
                    _view.phone,
                    _view.email
                );
                refreshData();
            }
            catch (Exception ex)
            {
                _view.showMessage(ex.Message);
            }
        }

        public void deleteSupplier(int id)
        {
            try
            {
                _repository.deleteSupplier(id);
                refreshData();
            }
            catch (Exception ex)
            {
                _view.showMessage(ex.Message);
            }
        }
    }
}
