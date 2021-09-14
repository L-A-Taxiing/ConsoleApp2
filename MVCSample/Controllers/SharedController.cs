using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    [ChildActionOnly]  //不能通过请求直接访问
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult _User(int?level)
        {
            UserModel model = new UserModel
            {
                Id = 8,
                Name = "韩家宝"
            };
            ViewBag.level = 3;
            //partialveiw 不会引用layout
            return PartialView(model);
        }


        public PartialViewResult _LogOnStatus()
        {

            return PartialView();
        }
    }
}