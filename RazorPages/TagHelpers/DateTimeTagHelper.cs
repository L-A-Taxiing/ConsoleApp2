using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.TagHelpers
{
    [HtmlTargetElement("datetime",Attributes ="asp-showicon,asp-only")]
    public class DateTimeTagHelper:TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "small";

            if (context.AllAttributes["asp-showicon"].Value.ToString()=="true")
            {
                output.PreContent.SetHtmlContent("<span class=\"fa fa-calendar\"></span>");
                output.Attributes.RemoveAll("asp-showicon");
            }
            if (context.AllAttributes["asp-only"].Value.ToString()=="date")
            {
                output.Content.SetHtmlContent(Convert.ToDateTime(output.GetChildContentAsync().Result.GetContent()).ToString("yyyy年MM月dd日"));
                output.Attributes.RemoveAll("asp-only");
            }

            base.Process(context, output);
        }
    }
}
