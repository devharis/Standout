using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWTS.Controllers;
using SWTS.Models;

namespace SWTS.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Supplier()
        {
            const int id = 15;
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Supplier(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddSupplier()
        {

            // Arrange
            var controller = new HomeController();
            var model = new Supplier("Shell", "Daléngatan 7", 39238, "Kalmar", "Sweden", "info@shell.se", "0706380129", Category.Tobacco, 52.00, 24.00);

            // Act
            var result = controller.AddSupplier(model) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteSupplier()
        {
            const int id = 15;
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.DeleteSupplier(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
