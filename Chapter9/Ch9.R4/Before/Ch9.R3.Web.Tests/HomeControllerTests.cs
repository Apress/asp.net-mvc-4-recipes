using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ch9.R3.Web.Controllers;
using System.Web.Mvc;
using Ch9.R3.Web.Models;

namespace Ch9.R3.Web.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexAction_ReturnsNewsItemOfTheDayModel_ToIndexView()
        {
            //arrange
            var homeController = new HomeController();
            
            //act
            var result  = homeController.Index() as ViewResult;

            //assert
            var model = result.Model as NewsItemOfTheDay;

            Assert.IsNotNull(model,"Model should of the type NewsItemOfTheDay");

        }
    }
}
