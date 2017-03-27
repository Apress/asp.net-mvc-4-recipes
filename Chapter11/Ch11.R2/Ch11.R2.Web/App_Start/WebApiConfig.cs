using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ch11.R2.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
            name: "PagingApi",
            routeTemplate: "api/{controller}/Page/{Page}/{SortExpression}",
    defaults: new
    {
        Page = 0,
        SortExpression = "CreateDate"
    },
    constraints: new
    {
        Page = @"\d+",
        SortExpression= "title|createdate|numbercomments|username"
    }

);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}
