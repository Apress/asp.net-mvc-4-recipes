using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ch9.R4.Web.Controllers;
using System.Web.Mvc;
using Ch9.R4.Web.Models;

namespace Ch9.R4.Web.Tests.Controllers
{
    [TestClass]
    public class MSTestControllerTests
    {
        [TestInitialize]
        public void RunBeforeAllTestsInAssembly()
        {
        }

        [ClassInitialize]
        public static void RunBeforeAnyofTheTestsInThisClass(TestContext context)
        {
        }

        [TestMethod]
        [CssProjectStructure("UserExperience")]
        [CssIteration("Iteration 1")]
        [Description(@"Tests to verify that when it is 5PM in June that the 
            the Summerday sound effect wil be played")]
        [Owner("John")]
        [TestCategory("Controller Tests")]
        public void IndexAction_Is5PM_June_ReturnsDayModel_SoundEffectSummerDay()
        {
            //arrange
            string expected = "SummerDay";
            MSTestController controller = new MSTestController(new DateTime(2012, 6, 1, 17, 0, 0));
            //act
            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DayModel;
            Assert.IsNotNull(model, "Incorrect model, expected DayModel");
            Assert.AreEqual(expected, model.SoundEffect);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void IndexAction_Is3PM_Feb292016_ThrowsApplicationException()
        {
            //arrage
            MSTestController controller = new MSTestController(new DateTime(2016, 2, 29, 17, 0, 0));
            //act
            controller.Index();
        }

        [TestMethod]
        public void IndexAction_Is3PM_June_ReturnsDayModel_SceenSummerDay()
        {
            //arrange
            MSTestController controller = new MSTestController(new DateTime(2012, 6, 1, 14, 0, 0));
            string expected = "SummerDay";
            //act
            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DayModel;
            Assert.IsNotNull(model, "Incorrect model, expected DayModel");
            Assert.AreEqual(expected, model.SceneName);
        }

        [TestMethod]
        public void IndexAction_Is10PM_June_ReturnsDayModel_SceenNight()
        {
            //arrange
            MSTestController controller = new MSTestController(new DateTime(2012, 6, 1, 22, 0, 0));
            string expected = "Night";
            //act
            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DayModel;
            Assert.IsNotNull(model, "Incorrect model, expected DayModel");
            Assert.AreEqual(expected, model.SceneName);
        }

        [TestMethod]
        public void IndexAction_Is10PM_June_ReturnsDayModel_SoundEffectNight()
        {
            //arrange
            MSTestController controller = new MSTestController(new DateTime(2012, 6, 1, 22, 0, 0));
            string expected = "Night";
            //act
            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DayModel;
            //assert
            Assert.IsNotNull(model, "Incorrect model, expected DayModel");
            Assert.AreEqual(expected, model.SoundEffect);
        }



        [TestMethod]
        public void IndexAction_Is10PM_December_ReturnsModel_SoundEffectWinterStorm()
        {
            //arrange
            MSTestController controller = new MSTestController(new DateTime(2012, 12, 1, 22, 0, 0));
            string expected = "WinterStorm";
            //act
            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DayModel;
            //assert
            Assert.IsNotNull(model, "Incorrect model, expected DayModel");
            Assert.AreEqual(expected, model.SoundEffect);

        }

        [TestMethod]
        public void IndexAction_Is10AM_December_ReturnsModel_SceenWinterDay()
        {
            //arrange
            MSTestController controller = new MSTestController(new DateTime(2012, 12, 1, 10, 0, 0));
            string expected = "WinterDay";
            //act
            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DayModel;
            //assert
            Assert.IsNotNull(model, "Incorrect model, expected DayModel");
            Assert.AreEqual(expected, model.SceneName);
        }



        [ClassCleanup]
        public static void RunAfterAllTestsInClassHaveCompleted()
        {
        }

        [TestCleanup]
        public void RunsAfterAllCodeInTestAssemblyHasCompleted()
        {
        }
    }
}
