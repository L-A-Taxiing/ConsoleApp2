using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RazorPages.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Entities.User NewUser { get; set; }
        public bool RememberMe { get; set; }

        public int BirthMonths { get; set; }
        public IEnumerable<SelectListItem> AvailableMonths { get; set; }

        public void OnGet()
        {
            //NewUser = new Entities.User { Name = "大飞哥" };    //在进入注册页时显示
            //NewUser = new Entities.User { IsMale = false };

            //AvailaMonths = new List<SelectListItem>
            //{
            //new SelectListItem("一月","1"),
            //new SelectListItem {Text="二月",Value="2" },
            //new SelectListItem("三月","3",true)
            //};

            //AvailaMonths = new SelectList(new int[] { 1, 2, 3, 4, 5 },3);

            AvailableMonths = new SelectList(new ArticleRepository().Get(1, 10), "Id", nameof(Entities.Article.Title));
        
        }
        public void OnPost()
        {
            string username = Request.Form["NewUser.Name"];
            NewUser = new Entities.User { Name = username };

            //也可以用ViewData: ViewData["UserName"] = Request.Form["NewUser.Name"];
        }
    }
}
