using Ch11.R2.Web.Controllers;
using Ch11.R2.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Ch11.R2.Web.Tests.Controllers
{
    [TestClass]
    public class CollaborationSpaceControllerTests
    {
        [TestMethod]
        public void Get_PageNullSortNull_ReturnPage1SortedByCreateDate()
        {
            // Arrange
            var mock = new Mock<IAjaxDataGridRepository>();
            CollaborationSpacesController controller = new CollaborationSpacesController(mock.Object);

            // Act
            CollaborationSpaceSearchResultModel result = controller.Get(null, null);

            // Assert
            Assert.AreEqual(1, result.CurrentPage);
            Assert.AreEqual("CreateDate", result.SortExpression);

        }
    }
}
