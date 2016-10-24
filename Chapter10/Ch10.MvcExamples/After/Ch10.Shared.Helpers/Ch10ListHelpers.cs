using System;
using System.Collections;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security.AntiXss;

namespace Ch10.Shared.Helpers
{

    public static class  Ch10ListHelpers
    {
        public static MvcHtmlString ConcatProperty(this HtmlHelper helper, params string[] text)
        {
            if (text != null)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    if (!string.IsNullOrEmpty(text[i]))
                    {                      
                        builder.Append(AntiXssEncoder.HtmlEncode(text[i],true));
                        if (i < text.Length - 1)
                        {
                            builder.Append("<br/>");                        
                        }
                    }
                }
                return MvcHtmlString.Create(builder.ToString());
            }
            return MvcHtmlString.Empty;
        }

        

        
    }
  
}
