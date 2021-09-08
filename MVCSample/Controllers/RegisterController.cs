using MVCSample.Filters;
using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [ModelErrorTransferFilter]
        public ActionResult Index()
        {
            ////首先有一个cookie，名字叫user
            //HttpCookie cookie = new HttpCookie("user");

            ////在cookie中添加若干个键值对
            //cookie.Values.Add("id", "98");
            //cookie.Values.Add("pwd", "1234");

            //cookie.Expires = DateTime.Now.AddDays(14);
            //Response.Cookies.Add(cookie);

            ////cookie取和删除
            //HttpCookie cookie = Request.Cookies["user"];
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //Response.Cookies.Add(cookie);


            Session["User"] = new RegisterModel { Name = "飞哥" };
         
            //if (TempData[Keys.ErrorInModel]!=null)
            //{
            //    ModelState.Merge(TempData[Keys.ErrorInModel] as ModelStateDictionary);
            //}
            RegisterModel model = new RegisterModel
            {
                Name = "大飞哥",
                Password = "1234",
                Rest = new List<RestItem>
                {
                    new RestItem { DayOfWeek = DayOfWeek.Monday },
                    new RestItem { DayOfWeek = DayOfWeek.Tuesday },
                    new RestItem { DayOfWeek = DayOfWeek.Wednesday },
                    new RestItem { DayOfWeek = DayOfWeek.Thursday },
                    new RestItem { DayOfWeek = DayOfWeek.Friday },
                    new RestItem { DayOfWeek = DayOfWeek.Saturday },
                    new RestItem { DayOfWeek = DayOfWeek.Sunday },


                },

                Keywords = new List<SelectListItem>
                {
                    new SelectListItem{Text="SQL",Value="1"},
                    new SelectListItem{Text="C#",Value="2"},
                    new SelectListItem{Text="Java",Value="3"}

                }

            };
            return View(model);
        }



        [HttpPost]
        public ActionResult Index(int? id, string name, RegisterModel model)
        {
           
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //return View();

            //if (!ModelState.IsValid)
            //{
            //    TempData[Keys.ErrorInModel] = ModelState;
            //    return RedirectToAction(nameof(Index));
            //}
            return View(model);

        }

    }


}