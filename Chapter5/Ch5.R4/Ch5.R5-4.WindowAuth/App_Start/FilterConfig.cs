using System.Web;
using System.Web.Mvc;

namespace Ch5.R5_4.WindowAuth
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}