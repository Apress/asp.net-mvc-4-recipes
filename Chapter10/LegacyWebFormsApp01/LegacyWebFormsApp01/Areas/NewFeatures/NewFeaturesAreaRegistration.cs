using System.Web.Mvc;

namespace LegacyWebFormsApp01.Areas.NewFeatures
{
    public class NewFeaturesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "NewFeatures";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "NewFeatures_default",
                "NewFeatures/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
