using Ch9.R7.Web.Controllers;
using NUnit.Framework;
using System.Web.Mvc;

namespace Ch9.R7.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexAction_ReturnsIndexView()
        {
            //arrange
            HomeController controller = new HomeController();
            string expected = "Index";

           // act
            var result = controller.Index() as ViewResult;

            //assert
            Assert.AreEqual(result.ViewName, expected);
        }
    }
}
