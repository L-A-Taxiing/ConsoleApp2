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
        public IndexModel()
        {
            articleRepositories = new ArticleRepository();
        }
        public IList<E.Article> Articles{ get; set; }

        public void OnGet()
        {
            Articles = articleRepositories.Get();





        }
    }
}
