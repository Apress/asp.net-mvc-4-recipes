using Ch9.R2.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace Ch9.R2.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexAction_ReturnsMessageInViewBag()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Modify this template to jump-start your ASP.NET MVC application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void IndexAction_ReturnsIndexView()
        {
            //Arrange
            string expected = "Index";
            var homeController = new HomeController();

            //Act
            var result = homeController.Index() as ViewResult;

            //Assert
            Assert.AreEqual(expected, result.ViewName, "Unexpected view name");
        }

        [TestMethod]
        public void AboutAction_ReturnsMessageInViewBag()
        {
            //Arrange
            string expected = "Your app description page.";
            var homeController = new HomeController();

            //Act
            var result = homeController.About() as ViewResult;

            //Assert
            Assert.AreEqual(expected, result.ViewBag.Message, "ViewBag message incorrect");
        }

        [TestMethod]
        public void AboutAction_ReturnsAboutView()
        {
            //Arrange
            string expected = "Contact";
            var homeController = new HomeController();

            //Act
            var result = homeController.Contact() as ViewResult;

            //Assert
            Assert.AreEqual(expected, result.ViewName, "Unexpected view name");
        }

        [TestMethod]
        public void ContactAction_ReturnsMessageInViewBag()
        {
            //Arrange
            string expected = "Your contact page.";
            var homeController = new HomeController();

            //Act
            var result = homeController.Contact() as ViewResult;

            //Assert
            Assert.AreEqual(expected, result.ViewBag.Message, "ViewBag message incorrect");
        }

        [TestMethod]
        public void ContactAction_ReturnsContactView()
        {
            //Arrange
            string expected = "Contact";
            var homeController = new HomeController();

            //Act
            var result = homeController.Contact() as ViewResult;

            //Assert
            Assert.AreEqual(expected, result.ViewName, "Unexpected view name");
        }
    }
}
