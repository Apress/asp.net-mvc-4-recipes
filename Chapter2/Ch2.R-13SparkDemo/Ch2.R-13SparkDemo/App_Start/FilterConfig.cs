using System.Web;
using System.Web.Mvc;

namespace Ch2.R_13SparkDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}