using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Ch10.Shared.Helpers
{
    public static class WizardHelpers
    {
        public static MvcHtmlString WizardBackButton(this HtmlHelper helper, string actionName, string controller)
        {
            if (validateAC(actionName, controller))
            {
                return createPostBackLink(helper, "Back", actionName, controller);
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString WizardNextButton(this HtmlHelper helper, string actionName, string controller)
        {
            if (validateAC(actionName, controller))
            {
                return createPostBackLink(helper, "Next", actionName, controller);
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString WizardFinishButton(this HtmlHelper helper, string actionName, string controller)
        {
            if (validateAC(actionName,controller))
            {
                return createPostBackLink(helper, "Finish", actionName, controller);
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString WizardSideButton(this HtmlHelper helper, string text, string actionName, string controller)
        {
            if (validateAC(actionName, controller))
            {
                return createPostBackLink(helper, text, actionName, controller);
            }
            return MvcHtmlString.Empty;
        }

        private static MvcHtmlString createPostBackLink(HtmlHelper helper, string text, string actionName, string controller)
        {
            string actionUrl = helper.ViewContext.RouteData.Route.GetVirtualPath(helper.ViewContext.RequestContext,
                    new RouteValueDictionary { { "controller", controller }, { "action", actionName } }).VirtualPath;

            return MvcHtmlString.Create(String.Format(@"<a href=""#"" onclick=""WizardSubmit('{0}')"">{1}</a>",
              actionUrl, text));
        }

        private static bool validateAC(string a, string c)
        {
            if (!String.IsNullOrEmpty(a) && !String.IsNullOrEmpty(c))
            {
                return true;
            }
            return false;
        }
    }

    
}
