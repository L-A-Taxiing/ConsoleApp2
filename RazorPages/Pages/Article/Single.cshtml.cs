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
        private ArticleRepository articleRepository;        //声明一个字段
        public SingleModel()
        {
            articleRepository = new ArticleRepository();    //实例化
        }
        public Article Article { get; set; }             //Model里面有一个Entity对象

        public void OnGet()
        {
            Article = articleRepository.Find(8);   //通过Repository拿到Entity对象
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
                   Title = @"高阶:泛型/集合/Lambda/异常/IO/多线程",
                   Body = @"泛型 可以有泛型方法/类等，同C#",

                   Author = new User
                   {
                     Id = 23,
                     Name = "大飞哥"
                   }
                }
            };
        }



        //如果要在构造函数中实例，构造函数必须是静态的

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
