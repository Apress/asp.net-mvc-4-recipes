using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace Ch11.R2.Web.Tests
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void PagingApiRoute_TitleAsSortExpression_IsMatch()
        {
            //arrange
            var config = new HttpConfiguration();
            var routes = new RouteCollection();
            WebApiApplication.RegisterRoutes(routes, config);

            //act
            var apiRouteData = 
                config.Routes.GetRouteData(new HttpRequestMessage(HttpMethod.Get,
                    "http://someurl/api/CollaborationSpaces/Page/2/Title"));

            //assert
            Assert.IsNotNull(apiRouteData);

        }

        [TestMethod]
        public void PagingApiRoute_FooAsSortExpression_IsNotMatch()
        {
            var config = new HttpConfiguration();
            var routes = new RouteCollection();
            WebApiApplication.RegisterRoutes(routes, config);

            var apiRouteData =
                config.Routes.GetRouteData(new HttpRequestMessage(HttpMethod.Get, 
                    "http://someurl/api/CollaborationSpaces/Page/2/Foo"));


            Assert.IsNull(apiRouteData);

        }


        [TestMethod]
        public void PagingApiRoute_FooAsPage_IsNotMatch()
        {
            var config = new HttpConfiguration();
            var routes = new RouteCollection();
            WebApiApplication.RegisterRoutes(routes, config);


            var apiRouteData =
                config.Routes.GetRouteData(new HttpRequestMessage(HttpMethod.Get, 
                    "http://someurl/api/CollaborationSpaces/Page/Foo/Title"));


            Assert.IsNull(apiRouteData);

        }

        [TestMethod]
        public void PagingApiRoute_CollaborationSpaces_ControllerMatch()
        {
            var config = new HttpConfiguration();
            var routes = new RouteCollection();
            WebApiApplication.RegisterRoutes(routes, config);

            var apiRouteData =
                config.Routes.GetRouteData(new HttpRequestMessage(HttpMethod.Post, 
                    "http://someurl/api/CollaborationSpaces/Page/1/Title"));

            Assert.IsNotNull(apiRouteData);
            Assert.AreEqual("CollaborationSpaces", apiRouteData.Values["controller"]);

        }

        
        
    }
}
