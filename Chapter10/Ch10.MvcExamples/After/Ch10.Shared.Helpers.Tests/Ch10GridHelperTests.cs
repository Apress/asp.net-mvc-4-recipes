using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Web.Mvc;
using Rhino.Mocks;

namespace Ch10.Shared.Helpers.Tests
{
    [TestFixture]
    public class Ch10GridHelperTests
    {

        [Test]
        public void CreateNumericPager_1PagesOnPage1_ReturnsEmptyString()
        {
            // Arrange
            HtmlHelper helper = MockHtmlHelpers.CreateMockHelper();
            //act
            string expected = string.Empty;
            string actual = helper.CreateNumericPager(20, 20, 1).ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateNumericPager21PagesOnPage9_ReturnsStart1End20()
        {
            // Arrange
            HtmlHelper helper = MockHtmlHelpers.CreateMockHelper();
            int expectedStart = 1;
            int expectedEnd = 20;
            int startPage, endPage;
            string result = helper.CreateNumericPager(10*21, 10, 9, out startPage, out endPage).ToString();
            Assert.AreEqual(expectedStart, startPage);
            Assert.AreEqual(expectedEnd, endPage);
        }

        [Test]
        public void CreateNumericPager69PagesOnPage69_ReturnsStart49End69()
        {
            // Arrange
            HtmlHelper helper = MockHtmlHelpers.CreateMockHelper();
            int expectedStart = 49;
            int expectedEnd = 69;
            int startPage, endPage;
            string result = helper.CreateNumericPager(695, 10, 69, out startPage, out endPage).ToString();
            Assert.AreEqual(expectedStart, startPage);
            Assert.AreEqual(expectedEnd, endPage);
        }

        [Test]
        public void CreateNumericPager69PagesOnPage68_ReturnsStart49End69()
        {
            // Arrange
            HtmlHelper helper = MockHtmlHelpers.CreateMockHelper();
            int expectedStart = 49;
            int expectedEnd = 69;
            int startPage, endPage;
            string result = helper.CreateNumericPager(695, 10, 68, out startPage, out endPage).ToString();
            Assert.AreEqual(expectedStart, startPage);
            Assert.AreEqual(expectedEnd, endPage);
        }

    }
}
