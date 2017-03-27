using System.Web.Mvc;

namespace Ch7.R9.Areas.Collaboration
{
    public class CollaborationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Collaboration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Collaboration_default",
                "Collaboration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
