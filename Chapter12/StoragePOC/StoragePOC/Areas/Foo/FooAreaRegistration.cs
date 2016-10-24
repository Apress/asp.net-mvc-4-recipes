using System.Web.Mvc;

namespace StoragePOC.Areas.Foo
{
    public class FooAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Foo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Foo_default",
                "Foo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
