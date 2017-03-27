using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Ch10.Shared.Helpers.Tests
{
    [TestFixture]
    public class Ch10HelpersRenderTemplateAsColumns
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void RenderTemplateAsColumns_ZeroColumns_ThrowsException()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            List<string> strings = new List<string>();
            //act
            helper.RenderTemplateAsColumns(strings, "foo", 0);
            //Assert
            
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void RenderTemplateAsColumnsDelegate_ZeroColumns_ThrowsException()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            List<string> strings = new List<string>();
            //act
            helper.RenderTemplateAsColumns(strings, "foo", 0, helper.Partial);
            //Assert

        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentNullException))]
        public void RenderTemplateAsColumns_NullCollection_ThrowsException()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            //act
            helper.RenderTemplateAsColumns(null, "foo", 3);
            //Assert

        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentNullException))]
        public void RenderTemplateAsColumnsDelegate_NullCollection_ThrowsException()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            //act
            helper.RenderTemplateAsColumns(null, "foo", 3, helper.Partial);
            //Assert

        }

        [Test]
        public void RenderTemplateAsColumns_5StringsCollection3Columns_OneExtraColumn()
        {
            // Arrange
            HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());
            List<string> strings = new List<string> { "1", "2", "3","4","5"};
            MvcHtmlString expected = MvcHtmlString.Create("<table><tr><td><b>1</b></td><td><b>2</b></td><td><b>3</b></td></tr><tr><td><b>4</b></td><td><b>5</b></td><td></td></tr></table>");
            //act
            MvcHtmlString actual = helper.RenderTemplateAsColumns(strings, "foo", 3, (a, b) => { return MvcHtmlString.Create(String.Format("<b>{0}</b>", b)); });
            //Assert
            Assert.AreEqual(expected.ToString(), actual.ToString());

        }
    }
}
