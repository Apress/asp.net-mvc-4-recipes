using System;
using System.Collections;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Ch10.Shared.Helpers
{
    public delegate MvcHtmlString GetStringFromAction(string ActionName, object model);
    public static class Ch10ColumnHelpers
    {
        public static MvcHtmlString RenderTemplateAsColumns(this HtmlHelper helper,
            ICollection items,
            string partialViewName,
            int numberOfColumns)
        {
            return RenderTemplateAsColumns(helper, items, partialViewName, numberOfColumns, helper.Partial);

        }
        public static MvcHtmlString RenderTemplateAsColumns(this HtmlHelper helper,
            ICollection items,
            string partialViewName,
            int numberOfColumns,
            GetStringFromAction getStringMethod)
        {
            if (numberOfColumns < 1)
            {
                throw new ArgumentOutOfRangeException("numberOfColumns");
            }
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }
            if (items == null || items.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                int columnsInRow = 1; 
                int rowsDone = 0; 
                int numberOfItemsDone = 0;
                int numberOfExtraColumnsInLastRow;
                int numberOfRows = items.Count / numberOfColumns;
                builder.Append("<table>");
                foreach (var item in items)
                {

                    if (columnsInRow == 1)
                    {
                        builder.Append("<tr>");
                    }
                    builder.Append("<td>");
                    builder.Append(getStringMethod(partialViewName, item));
                    builder.Append("</td>");
                    bool isLastItem = (items.Count == numberOfItemsDone + 1);
                    if ((columnsInRow == numberOfColumns) || isLastItem)
                    {
                        if (isLastItem)
                        {
                            numberOfExtraColumnsInLastRow = numberOfColumns - columnsInRow;
                            builder.Append(RenderExtraColumns(numberOfExtraColumnsInLastRow));
                        }
                        builder.Append("</tr>");
                        columnsInRow = 1;
                        rowsDone++;
                    }
                    else
                    {
                        columnsInRow++;
                    }
                    numberOfItemsDone++;


                }
                builder.Append("</table>");
                return MvcHtmlString.Create(builder.ToString());
            }
            return MvcHtmlString.Empty;
        }

        private static string RenderExtraColumns(int numberOfExtraColumnsInLastRow)
        {
            if (numberOfExtraColumnsInLastRow > 0)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < numberOfExtraColumnsInLastRow; i++)
                {
                    builder.Append("<td></td>");
                }
                return builder.ToString();
            }
            return string.Empty;

        }
    }
}
