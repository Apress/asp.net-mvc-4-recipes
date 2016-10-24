using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Ch10.Shared.Helpers
{
    public static class EditInPlaceHelpers
    {

        public static MvcHtmlString DataGridEditorFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            bool isSelected,
            Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            if (isSelected)
            {
                return MvcHtmlString.Create(helper.EditorFor(expression).ToString());
            }
            else
            {
                return MvcHtmlString.Create(helper.DisplayFor(expression).ToString());
            }
        }

        public static MvcHtmlString DataGridTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, 
            bool isSelected,
            Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            if (isSelected)
            {
                return MvcHtmlString.Create(helper.TextBoxFor(expression).ToString());
            }
            else
            {
                return MvcHtmlString.Create(helper.DisplayFor(expression).ToString());
            }
        }

        public static MvcHtmlString DataGridTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper,
            bool isSelected,
            Expression<Func<TModel, TProperty>> expression) where TModel : class
        {
            if (isSelected)
            {
                return MvcHtmlString.Create(helper.TextAreaFor(expression).ToString());
            }
            else
            {
                return MvcHtmlString.Create(helper.DisplayFor(expression).ToString());
            }
        }
    }
}
