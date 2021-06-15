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
        private ArticleRepository articleRepository;        //����һ���ֶ�
        public SingleModel()
        {
            articleRepository = new ArticleRepository();    //ʵ����
        }
        public E.Article Article { get; set; }             //Model������һ��Entity����

        public void OnGet()
        {
            Article = articleRepository.Find(8);   //ͨ��Repository�õ�Entity����
        }
    }

   
   

   

   
}
