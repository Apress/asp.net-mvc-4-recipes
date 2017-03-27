using System;
using System.Collections;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.Security.AntiXss;

namespace Ch10.Shared.Helpers
{
    public static class Ch10GridHelpers
    {
        public static MvcHtmlString CreateNumericPager(this HtmlHelper helper, int totalNumResults, int itemsPerPage, int currentPage)
        {
            int startPage, endPage;
            return CreateNumericPager(helper, totalNumResults, itemsPerPage, currentPage, out startPage, out endPage);

        }

        public static MvcHtmlString CreateNumericPager(this HtmlHelper helper, int totalNumResults, int itemsPerPage, int currentPage,
            out int startPage, out int endPage)
        {
            if (totalNumResults <= itemsPerPage)
            {
                //no pager needed
                startPage = 0;
                endPage = 0;
                return MvcHtmlString.Empty;

            }
            else
            {
                int numberOfPages = totalNumResults / itemsPerPage;
                int maxNumberOfPagesShown = 20;
                bool showFirstAndLast = numberOfPages > maxNumberOfPagesShown;              
                startPage = getStartPage(numberOfPages, currentPage);
                endPage = getEndPage(numberOfPages, currentPage, startPage);

                StringBuilder builder = new StringBuilder();
                builder.Append("<ul>");
                if (showFirstAndLast && startPage>1)
                {
                    builder.Append("<li>");
                    builder.Append(buildActionLink(helper, "...", 1));
                    builder.Append("</li>");
                }

                for (int i = startPage; i <= endPage; i++)
                {
                    string PageLinkText = i.ToString();
                    builder.Append("<li>");
                    if (i != currentPage)
                    {
                        builder.Append(buildActionLink(helper, PageLinkText, i));
                    }
                    else
                    {
                        builder.Append(i);
                    }
                    builder.Append("</li>");

                }

                if (showFirstAndLast && (endPage!= numberOfPages))
                {
                    builder.Append("<li>");
                    builder.Append(buildActionLink(helper, "...", numberOfPages));
                    builder.Append("</li>");
                }

                builder.Append("</ul>");
                return MvcHtmlString.Create(builder.ToString());
            }
        }

        private static string buildActionLink(HtmlHelper helper, string linkText, int pageParam)
        {
            if (helper.ViewContext.HttpContext.Request.QueryString.HasKeys())
            {
                string sort = helper.ViewContext.HttpContext.Request.QueryString["SortExpression"];
                string categoryId = helper.ViewContext.HttpContext.Request.QueryString["CategoryId"];
                return helper.ActionLink(linkText,
                    helper.ViewContext.RouteData.Values["action"].ToString(), new { SortExpression = sort, CategoryId = categoryId, Page = pageParam }).ToString();
            }
            else
            {
                return helper.ActionLink(linkText,
                    helper.ViewContext.RouteData.Values["action"].ToString(), new { Page=pageParam}).ToString();
            }
        }

        private static int getEndPage(int numberOfPages, int currentPage, int startPage)
        {
            int maxToDisplay =startPage + 19;
            if (maxToDisplay > numberOfPages) { maxToDisplay = maxToDisplay - (maxToDisplay - numberOfPages); }
            if ((currentPage > numberOfPages - 10) && (startPage!=1)) { maxToDisplay = numberOfPages; }
            return maxToDisplay;
        }

        private static int getStartPage(int numberOfPages, int currentPage)
        {
            int minToDisplay = 1;
            if (currentPage > 10 )
            {
                minToDisplay = currentPage - 9;
            }
            if ((currentPage > numberOfPages - 10) && (numberOfPages > 20))
            {
                minToDisplay = numberOfPages - 20;
            }
            return minToDisplay;
        }
    }
}
