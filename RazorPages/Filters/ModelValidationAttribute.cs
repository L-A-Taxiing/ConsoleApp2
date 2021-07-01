using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Filters
{
    public class AutoModelValidationAttribute:Attribute,IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }
        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {

            ///1.把ModelState中的错误信息装入TempData
            if (context.HandlerMethod.HttpMethod== "Post")    //POST
            {
                //1.从ModelState中提取Error信息
                Dictionary<string, string> errors =
                    context.ModelState.Where(m => m.Value.Errors.Any())
                    .ToDictionary(
                        m => m.Key,
                        m => m.Value.Errors
                        .Select(s => s.ErrorMessage)
                        .FirstOrDefault(s => s != null));
                //2.将Error信息存放到TempData
                ((PageModel)context.HandlerInstance).TempData[Keys.ErrorInfo] = errors;
                //有Error重定向
                //context.Result = new RedirectToPageResult("/Log/On");

            }
            ///2.从TempDta取出ModelState中的错误信息
            else        //GET
            {
                //3. 从TempData里取出Error信息
                Dictionary<string, string> errors = ((PageModel)context.HandlerInstance).TempData[Keys.ErrorInfo] as Dictionary<string, string>;
                if (errors != null)
                {
                    //4. 将Error信息添加到ModelState  foreach (var item in errors)
                    foreach (var item in errors)
                    {
                        context.ModelState.AddModelError(item.Key, item.Value);
                    }


                }
            }

        }
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {

        }
    }
}
