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
        public ActionResult Index()
        {
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
    }

}