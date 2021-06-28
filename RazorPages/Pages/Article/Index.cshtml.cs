using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Repositories;
using E = RazorPages.Entities;


namespace RazorPages.Pages.Article
{
    public class IndexModel : PageModel
    {
        private ArticleRepository articleRepositories;
        public int Index { get; set; }
        public IndexModel()
        {
            articleRepositories = new ArticleRepository();
        }
        public IList<E.Article> Articles { get; set; }
        public int ArticleNums { get; set; }

        public void OnGet()
        {
            int pageIndex = Convert.ToInt32(Request.Query["pageIndex"][0]);
            Articles = articleRepositories.Get(pageIndex, 2);
            ArticleNums = articleRepositories.ArticleNum();
            Index = pageIndex;
        }
       
    }
}
