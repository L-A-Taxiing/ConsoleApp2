using SRV.ServiceInterface;
using SRV.ViewModel;
using SRV.ViewModel.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class LogController : Controller
    {
        private IUserService userService;
        public LogController()
        {
            userService = new SRV.ProdService.UserService();
        }
        // GET: Log
        public ActionResult On()
        
        {
            return View();
        }

        [HttpPost]
        public ActionResult On(OnModel model)
        {
            //bool result = userService.GetByName(model.Name, out string pwd); flexible
            UserModel result = userService.GetByName(model.Name);
            if (result==null)
            {
                ModelState.AddModelError("", "*用户名不存在");
                return View();
            }
            if (result.Password==model.Password)
            {
                ModelState.AddModelError("", "*密码错误");
                return View();
            }
            int userId = result.Id;




            return View();
        }
    }
}