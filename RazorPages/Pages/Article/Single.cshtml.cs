using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Article
{
    public class SingleModel : PageModel
    {
        private ArticleRepository articleRepository;        //����һ���ֶ�
        public SingleModel()
        {
            articleRepository = new ArticleRepository();    //ʵ����
        }
        public Article Article { get; set; }             //Model������һ��Entity����

        public void OnGet()
        {
            Article = articleRepository.Find(8);   //ͨ��Repository�õ�Entity����
        }
    }

    internal class ArticleRepository
    {
        private static IList<Article> articles /*= new List<Article>()*/;

        static ArticleRepository()
        {
            articles = new List<Article>
            {
                new Article
                {
                   Id=8,
                   Title = @"�߽�:����/����/Lambda/�쳣/IO/���߳�",
                   Body = @"���� �����з��ͷ���/��ȣ�ͬC#",

                   Author = new User
                   {
                     Id = 23,
                     Name = "��ɸ�"
                   }
                }
            };
        }



        //���Ҫ�ڹ��캯����ʵ�������캯�������Ǿ�̬��

        public ArticleRepository()
        {

        }

        internal Article Find(int id)
        {
            return articles.Where(a => a.Id == id).SingleOrDefault();
            //return article;
        }

        void Delete()
        {

        }

        public int Save(Article article)
        {
            articles.Add(article);
            return article.Id;
        }
    }

    public class Article : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }

    }

    public class User : Entity
    {
        public string Name { get; set; }
    }

    public class Entity
    {
        public int Id { get; set; }

    }
}
