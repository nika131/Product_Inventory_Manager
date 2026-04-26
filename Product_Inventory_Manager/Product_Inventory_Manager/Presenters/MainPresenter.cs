using Product_Inventory_Manager.Data;
using Product_Inventory_Manager.Repositories;
using Product_Inventory_Manager.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Product_Inventory_Manager.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly IProductRepository _repository;

        public MainPresenter(IMainView view, IProductRepository repository)
        {
            _view = view;
            _repository = repository;
        }

        public void refreshData()
        {
            try
            {
                DataTable dt = _repository.getAll();
                _view.gridDataSource = dt;
                updateCalculations(dt);
            }
            catch (Exception ex)
            {
                _view.showError(ex.Message);
            }
        }

        public void search(string keyword)
        {
            try
            {
                DataTable dt = _repository.search(keyword);
                _view.gridDataSource = dt;
                updateCalculations(dt);
            }
            catch (Exception ex) 
            {
                _view.showError(ex.Message);
            }
        }

        public void updateCalculations(DataTable dt)
        {
            if (dt == null) return;

            int totalItmes = dt.Rows.Count;
            decimal totalValue = 0;
            int lowStock = 0;
            decimal totalPotentialProfit = 0;

            foreach (DataRow row in dt.Rows)
            {
                decimal price = Convert.ToDecimal(row["ProductPrice"]);
                decimal costPrice = Convert.ToDecimal(row["costPrice"]);
                int qty = Convert.ToInt32(row["Quantity"]);

                totalValue += (price * qty);
                totalPotentialProfit += ((price - costPrice) * qty);
                if (qty < 5) lowStock++;
            }

            _view.totalItemsText = $"Total Products: {totalItmes}";
            _view.totalValueText = $"Total Value: {totalValue:C}";
            _view.totalProfitText = $"Total Potential Profit: {totalPotentialProfit:C}";
            _view.lowStockText = $"Low Stock Alerts: {lowStock}";
            _view.lowStockColor = lowStock > 0 ? Color.Red : Color.Black;
        }

        public void deleteProduct (int id, string name)
        {
            if (_view.confirmDelete(name))
            {
                try
                {
                    _repository.delete(id);
                    refreshData();
                }
                catch (Exception ex)
                {
                    _view.showError(ex.Message);
                }
            }
        }
    }
}
