using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ch10.Shared.Helpers.Tests
{
    
    public static class MockHtmlHelpers
    {
        public static HtmlHelper CreateMockHelper(string controllerName ="Home", 
            string actionName = "Index", 
            object routeId =null,
            NameValueCollection queryString = null)
        {
            var defaultQueryString = (queryString != null) ? queryString : new NameValueCollection();
            RouteData routeData = new RouteData();
            routeData.Values["controller"] = controllerName;
            routeData.Values["action"] = actionName;
            routeData.Values["id"] = routeId;

            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            var viewContext = MockRepository.GenerateStub<ViewContext>();
            var httpRequest = MockRepository.GenerateStub<HttpRequestBase>();
            var httpResponse = MockRepository.GenerateStub<HttpResponseBase>();
           

            httpContext.Stub(c => c.Request).Return(httpRequest).Repeat.Any();
            httpContext.Stub(c => c.Response).Return(httpResponse).Repeat.Any();
            httpResponse.Stub(r => r.ApplyAppPathModifier(Arg<string>.Is.Anything))
                        .Return(string.Format("/{0}/{1}/{2}", controllerName, actionName, routeId));
            httpContext.Request.Stub(c => c.QueryString).Return(defaultQueryString);

            viewContext.HttpContext = httpContext;
            viewContext.RequestContext = new RequestContext(httpContext, routeData);
            viewContext.RouteData = routeData;
            viewContext.ViewData = new ViewDataDictionary();
            viewContext.ViewData.Model = null;

            var helper = new HtmlHelper(viewContext, new ViewPage());
            if (helper.RouteCollection.Count == 0)
            {
                helper.RouteCollection.MapRoute(
                    "Default",                                              // Route name
                    "{controller}/{action}/{id}",                           // URL with parameters
                    new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
                );
            }
            return helper;

        }
    }
}
