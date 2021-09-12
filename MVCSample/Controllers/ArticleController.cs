using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ServiceInterface;
using SRV.ViewModel.Article;

namespace MVCSample.Controllers
{
    public class ArticleController : Controller
    {
        private IArticleService articleService;
     
        public ArticleController()
        {
            articleService = new ProdService.ArticleService();  //后端开发人员选择
            //articleService = new MockService.ArticleService();  //前端开发人员选择
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

            int id=articleService.Publish(model, CurrentUserId);

            return RedirectToAction("Single",new {id=id });
        }
         

        public ActionResult Single(int id)
        {
            SingleModel model = articleService.GetById(id);
            return View(model);



        }









    }
}