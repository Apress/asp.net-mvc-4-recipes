using Ch9.R8.Web.Controllers;
using Ch9.R8.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web.Routing;

namespace Ch9.R8.Web.Tests.Controllers
{
    
    [TestClass]
    public class ArchitectControllerTests
    {
 
        #region Index Action
        [TestMethod]
        public void IndexAction_ReturnsIndexView()
        {
            // arrange
            string expected = "Index";
            var mock = new Mock<IArchitectRepository>();
            ArchitectController controller = new ArchitectController(mock.Object);

            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }

        [TestMethod]
        public void IndexAction_NoData_ViewBagMessageNoData()
        {
            // arrange
            string expected = "No architects found.";
            var mock = new Mock<IArchitectRepository>();
            mock.Setup(a => a.GetArchitectList()).Returns(new List<Architect>());
            ArchitectController controller = new ArchitectController(mock.Object);

            // act
            ViewResult result = controller.Index() as ViewResult;
            string actual = result.ViewBag.NoDataFoundMessage as string;

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IndexAction_ModelIsTypeOfArtistList()
        {
            // arrange
            var mock = new Mock<IArchitectRepository>();
            mock.Setup(a => a.GetArchitectList()).Returns(new List<Architect>());
            ArchitectController controller = new ArchitectController(mock.Object);

            // act
            ViewResult result = controller.Index() as ViewResult;
            // assert
            Assert.IsInstanceOfType(result.Model,typeof(List<Architect>));
        }

        [TestMethod]
        public void IndexAction_1ArchitectFound_ViewBagNumberFoundMessage1Found()
        {
            // arrange
            string expected = "1 architects found.";
            var mock = new Mock<IArchitectRepository>();
            mock.Setup(a => a.GetArchitectList()).Returns(new List<Architect>() { new Architect { ArchitectId = 1 } }
            );
            ArchitectController controller = new ArchitectController(mock.Object);

            // act
            ViewResult result = controller.Index() as ViewResult;
            string actual = result.ViewBag.NumberFoundMessage as string;

            // assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Create(Architect architect)
        [TestMethod]
        public void CreatePostAction_ModelStateValid_RedirectToIndexView()
        {
            // arrange
            string expected = "Index";
            var mock = new Mock<IArchitectRepository>();

            Architect architect = new Architect();
            ArchitectController controller = new ArchitectController(mock.Object);

            // act
            RedirectToRouteResult result = controller.Create(architect) as RedirectToRouteResult;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void CreatePostAction_ModelStateValid_UpdateAndSaveAreCalled()
        {
            // arrange
            var mock = new Mock<IArchitectRepository>();
            Architect architect = new Architect();
            ArchitectController controller = new ArchitectController(mock.Object);

            // act
            RedirectToRouteResult result = controller.Create(architect) as RedirectToRouteResult;

            // assert
            mock.Verify(a => a.Create(architect));
            mock.Verify(a => a.Save());
        }

        [TestMethod]
        public void CreatePostAction_ModelStateNotValid_ReturnCreateView()
        {
            // arrange
            string expected = "Create";
            var mock = new Mock<IArchitectRepository>();

            Architect architect = new Architect();
            ArchitectController controller = new ArchitectController(mock.Object);
            controller.ModelState.AddModelError("FirstName", "FirstName is required");

            // act
            ViewResult result = controller.Create(architect) as ViewResult;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }
        #endregion
    }
}
