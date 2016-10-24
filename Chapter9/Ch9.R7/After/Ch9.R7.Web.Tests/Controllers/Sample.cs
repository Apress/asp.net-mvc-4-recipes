using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ch9.R7.Web.Controllers;
using System.Web.Mvc;
using Ch9.R7.Web.Models;

namespace Ch9.R7.Web.Tests.Controllers
{
    [TestFixture]
    [Category("SampleTestClass")]
    public class NUnitTestControllerTests
    {

        [TestFixtureSetUp]
        public void Init(TestContext context)
        {
            // this runs once when the class is instantiated before any tests are run. 
        }

        [SetUp]
        public void RunBeforeAllTestsInClassAssembly()
        {
            // run before the test to allocate and configure resources 
            // needed. Will be run for each test in the class.add code that will run before any code in the entire
            //test assembly is executed
        }

        [Test, Explicit]
        public void IgnoredUnlessExplicitlySelectedFoRunning()
        {
            //ignored unless it is explicitly selected for running
            //If encountered in while running tests 
            //the test runner will treats  as ignored. 
            //The progress bar turns yellow  test listed as not run
        }

        [Test]
        [Platform(Exclude = "Mono,Unix,Linux")]
        public void DontRunIfOnUnix()
        {
            //specifies to include or exclude on certian platforms
            // Case insensitive, multiple values seperated by commas
            // full list of platforms provided here
            // http://www.nunit.org/index.php?p=platform&r=2.2.10
        }


        [Test]
        [Category("UserExperience")]
        [Description(@"Tests to verify that when it is 5PM in June that the 
            the Summerday sound effect wil be played")]
        public void IndexAction_Is5PM_June_ReturnsDayModel_SoundEffectSummerDay()
        {
            //arrange
            string expected = "SummerDay";
            NUnitTestController controller = new NUnitTestController(new DateTime(2012, 6, 1, 17, 0, 0));
            //act
            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DayModel;
            Assert.IsNotNull(model, "Incorrect model, expected DayModel");
            Assert.AreEqual(expected, model.SoundEffect);
        }

        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void IndexAction_Is3PM_Feb292016_ThrowsApplicationException()
        {
            //arrage
            NUnitTestController controller = new NUnitTestController(new DateTime(2016, 2, 29, 17, 0, 0));
            //act
            controller.Index();
        }

        [Test]
        [Ignore]
        public void IndexAction_Is3PM_June_ReturnsDayModel_SceenSummerDay()
        {
            //arrange
            NUnitTestController controller = new NUnitTestController(new DateTime(2012, 6, 1, 14, 0, 0));
            string expected = "SummerDay";
            //act
            var result = controller.Index() as ViewResult;
            var model = result.ViewData.Model as DayModel;
            Assert.IsNotNull(model, "Incorrect model, expected DayModel");
            Assert.AreEqual(expected, model.SceneName);
        }

        [TearDown]
        public void RunsAfterEachTestClassasCompleted()
        {
            //runs afer each test in a test class.
            // can be used to clean up resources from the test
        }

        [TestFixtureTearDown]
        public static void RunAfterAllTestsInTestClassHaveCompleted()
        {
            //use to clean up any resourses left over from the test
        }

    }

}
