using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCSample.Models.Article;
using ProdService;

namespace MVCSample.Controllers
{
    public class ArticleController : Controller
    {
        private UserService userService;
     
        public ArticleController()
        {
            userService = new UserService();   
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

            userService.Publish(model, CurrentUserId);

            return View();
        }










    }
}