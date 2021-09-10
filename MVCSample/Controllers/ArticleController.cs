using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSample.Models.Article;
using ServiceInterface;

namespace MVCSample.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService articleService;
     
        public ArticleController()
        {
            articleService = new ProdService.ArticleService();  //后端开发人员选择
            articleService = new MockService.ArticleService();  //前端开发人员选择
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

            articleService.Publish(model, CurrentUserId);

            return View();
        }










    }
}