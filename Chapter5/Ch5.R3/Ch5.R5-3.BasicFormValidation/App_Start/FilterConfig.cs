using System.Web;
using System.Web.Mvc;

namespace Ch5.R5_3.BasicFormValidation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}