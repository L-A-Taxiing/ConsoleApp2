using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Entities;
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


        public void OnGet()
        {
            Messages = messageRepository.GetMine();
        }
        public void OnPost()
        {
            foreach (var item in Messages)
            {
                if (item.Selected)
                {
                    messageRepository.Find(item.Id).Read();
                }
            }

        }
    }
}
