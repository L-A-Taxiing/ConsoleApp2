using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Entities;
using RazorPages.Filters;
using RazorPages.Repositories;

namespace RazorPages.Pages.Article
{
    public class MessageModel : PageModel
    {
        private MessageRepository messageRepository;
        public MessageModel()
        {
            messageRepository = new MessageRepository();
        }
        public string Name { get; set; }

        [BindProperty]
        public IList<Message> Messages { get; set; }

        //public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        //{
        //    base.OnPageHandlerSelected(context);
        //}
        //public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        //{
        //    base.OnPageHandlerExecuting(context);
        //}
        //public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        //{
        //    base.OnPageHandlerExecuted(context);
        //}
        //public override Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        //{
        //    return base.OnPageHandlerSelectionAsync(context);
        //}
        //public override Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        //{
        //    return base.OnPageHandlerExecutionAsync(context, next);
        //}


        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(Request.Cookies[Keys.UserId]))
            {
                return RedirectToPage("/Log/On");
            }
            Messages = messageRepository.GetMine(true);
            return Page();
        }
        public IActionResult OnPost()
        { 
            foreach (var item in Messages)
            {
                if (item.Selected)
                {
                    messageRepository.Find(item.Id).Read();
                }
            }
            //Messages = messageRepository.GetMine(true);
            return RedirectToPage();


        }
    }
}
