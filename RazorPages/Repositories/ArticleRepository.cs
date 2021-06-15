using RazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Repositories
{
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
                   },
                   PublishTime=new DateTime(2021,6,10,10,20,20)
                },
                new Article
                {
                   Id=10,
                   Title = @"Git远程：push / pull / clone / fetch / conflict",
                   Body = @"注意，之前所有操作，都是在本地（你自己的电脑上）进行的。要想和别人分享看到你的代码，你需要： PS：2019之前的版本需要在github上手动建立一个，然后再从VS同步到远程仓库（略） 然后，在Visual Studio上为什么是clone？要想在两个仓库之间同步，仓库和仓库之间必须“基因”相同的。怎么才能相同呢？以下情形任选其一：A仓库是从B仓库clone的A仓库向一个从未被使用过的（bare，不是empty）B仓库推送同步（sync）同步会首先比较远程repository和本地repository ……",
                   Author = new User
                   {
                     Id = 25,
                     Name = "小飞哥"
                   },
                   PublishTime=new DateTime(2021,6,14,15,30,15)
                }
            };
        }

        internal IList<Article> Get()
        {






            return articles;
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

}
