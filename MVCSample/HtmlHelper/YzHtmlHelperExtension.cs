using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace System.Web.Mvc.Html
{
    public static class YzHtmlHelperExtension
    {
        public static MvcHtmlString PageFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression)
        {
            Func<TModel,TProperty>func = expression.Compile();
            TProperty property = func(htmlHelper.ViewData.Model);

            string output = $"<a>{property}</a>";



            return new MvcHtmlString(output);
        }
    }
}