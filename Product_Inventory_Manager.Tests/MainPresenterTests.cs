using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product_Inventory_Manager.Presenters;
using Product_Inventory_Manager.Views.Interfaces;
using Product_Inventory_Manager.Repositories;
using NUnit.Framework;
using Moq;
using System.Data;
using System.Drawing;

namespace Product_Inventory_Manager.Tests
{
    [TestFixture]
    public class MainPresenterTests
    {
        private Mock<IMainView> _mockView;
        private Mock<IProductRepository> _mockRepo;
        private MainPresenter _presenter;

        [SetUp]
        public void setUp()
        {
            _mockView = new Mock<IMainView>();
            _mockRepo = new Mock<IProductRepository>();

            _presenter = new MainPresenter(_mockView.Object, _mockRepo.Object);
        }

        [Test]
        public void UpdateCalculations_CorrectlyCalculatesToTalValue()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductPrice", typeof(decimal));
            dt.Columns.Add("Quantity", typeof(int));

            dt.Rows.Add(5.00, 10);
            dt.Rows.Add(100.00, 2);

            _presenter.updateCalculations(dt);

            _mockView.VerifySet(v => v.totalValueText = It.Is<string>(s => s.Contains("250.00")),
                "The total value calculation logic is incorrect!");
        }

        [Test]
        public void UpdateCalculations_LowStock_SetColorToRed()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductPrice", typeof(decimal));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Rows.Add(10.00, 3);

            _presenter.updateCalculations(dt);

            _mockView.VerifySet(v => v.lowStockColor = Color.Red,
                "The UI should turn Red when stock is below 5!");
        }

        [Test]
        public void UpdateCalculations_HighStock_SetsColorToBlack()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductPrice", typeof(decimal));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Rows.Add(10.00, 10);

            _presenter.updateCalculations(dt);

            _mockView.VerifySet(v => v.lowStockColor = Color.Black,
                "The UI should stay Balck when stock is sufficient.");
        }
    }
}
