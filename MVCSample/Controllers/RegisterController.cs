using MVCSample.Filters;
using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.UI;
using SRV.ServiceInterface;

//Ctrl alt+w打开watch  ctrl \+E打开ErrorList
namespace MVCSample.Controllers
{
    public class RegisterController : Controller
    {

        //private UserRepository userRepository;
        private IUserService userService;
        public RegisterController()
        {
            //studentRepository = new UserRepository();
            userService = new SRV.MockService.UserService();
        }

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ModelErrorTransferFilter]
        public ActionResult Index(RegisterModel model)  //不要直接使用entitiy作为model 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //用户名是否重复
            //if (userRepository.GetByName(model.Name)!=null)
            //{
            //    ModelState.AddModelError("Name", "用户名不能重复");
            //    return RedirectToAction(nameof(Index));
            //}

            //User student = new User
            //{
            //    Name = model.Name,
            //    Password = model.Password
            //};
            //student.Register();
            //int id = userRepository.Save(student);

            //int UerId = userService.Register(model);
            //int UserId = 3;
            int UserId = userService.Register(model);
            HttpCookie cookie = new HttpCookie(Keys.User/*, UserId.ToString()*/);
            /* Response.Cookies.Add(new HttpCookie(Keys.User, UserId.ToString()));*///可以伪造
            cookie.Values.Add(Keys.Id, UserId.ToString());
            cookie.Values.Add(Keys.Password, UserId.ToString());
            Response.Cookies.Add(cookie);

            return View();


        }

    }


}