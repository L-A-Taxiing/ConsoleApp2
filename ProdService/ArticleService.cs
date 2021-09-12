using BLL.Entities;
using BLL.Repositories;
using ServiceInterface;
using SRV.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MVCSample.Models.Article;

namespace ProdService
{
    public class ArticleService : IArticleService
    {
        private ArticleRepository articleRepository;
        private UserRepository userRepository;
        public ArticleService()
        {
            SqlDbContext context = new SqlDbContext();
            articleRepository = new ArticleRepository(context);
            userRepository = new UserRepository(context);
        }

        public SingleModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Publish(NewModel model,int CurrentUserId)
        {
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body

            };

            //User author = userRepository.Find(CurrentUserId);
            User author = userRepository.LoadProxy(CurrentUserId);
            article.Author = author;
            articleRepository.Save(article);

            return article.Id;
        }








    }
}
