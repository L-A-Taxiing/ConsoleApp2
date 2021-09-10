using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Repositories;
using MVCSample.Models.Article;
using BLL.Entities;

namespace MVCSample.Controllers
{
    public class ArticleController : Controller
    {

        private ArticleRepository articleRepository;
        private UserRepository userRepository;
        public ArticleController()
        {
            SqlDbContext context = new SqlDbContext();
            articleRepository = new ArticleRepository(context);
            userRepository = new UserRepository(context);
        }
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult New()
        {

            return View();

        }


        [HttpPost]
        public ActionResult New(NewModel model)
        {
            int CurrentUserId = 3;
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body

            };

            //User author = userRepository.Find(CurrentUserId);
            User author = userRepository.LoadProxy(CurrentUserId);
            article.Author = author;
            articleRepository.Save(article);




            return View();
        }










    }
}