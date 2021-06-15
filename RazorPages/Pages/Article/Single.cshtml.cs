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
    public class SingleModel : PageModel
    {
        private ArticleRepository articleRepository;        //声明一个字段
        public SingleModel()
        {
            articleRepository = new ArticleRepository();    //实例化
        }
        public E.Article Article { get; set; }             //Model里面有一个Entity对象

        public void OnGet()
        {
            Article = articleRepository.Find(8);   //通过Repository拿到Entity对象
        }
    }

   
   

   

   
}
