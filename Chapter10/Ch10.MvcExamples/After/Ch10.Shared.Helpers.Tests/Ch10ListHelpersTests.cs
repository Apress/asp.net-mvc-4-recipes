using NUnit.Framework;
using System.Web.Mvc;
using System.Web.Security.AntiXss;
using Ch10.Shared.Helpers;

namespace Ch10.Shared.Helpers.Tests
{
    [TestFixture]
    public class ConcatPropertyHelpersTests
    {
        [Test]
        public void ConcatProperty_threeValuesNONulls_ReturnsThreeValuesseperatedByLineBreaks()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            //act
            string expected = "A<br/>B<br/>C";
            string actual = helper.ConcatProperty("A", "B", "C").ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConcatProperty_threeValuesMiddleValueNull_ReturnsTwoValuesseperatedByLineBreaks()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            string expected = "A<br/>C";
            //act
            string actual = helper.ConcatProperty("A", null, "C").ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConcatProperty_oneNulls_ReturnsEmptyString()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            string expected = string.Empty;
            //act
            string actual = helper.ConcatProperty(null).ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConcatProperty_oneValue_ReturnsOneValueNoBR()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            string expected = "A";
            //act
            string actual = helper.ConcatProperty("A").ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConcatProperty_oneEmptyString_ReturnsStringEmptyNoBR()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            string expected = string.Empty;
            //act
            string actual = helper.ConcatProperty("").ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConcatProperty_StringContainsHtml_ReturnsHtmlEncodedStringNoBR()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            string expected = AntiXssEncoder.HtmlEncode("<b>A</b>",true);
            //act
            string actual = helper.ConcatProperty("<b>A</b>").ToString();
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
