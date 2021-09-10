using MVCSample.Filters;
using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

//Ctrl alt+w打开watch  ctrl \+E打开ErrorList
namespace MVCSample.Controllers
{
    public class RegisterController : Controller
    {

        //private UserRepository userRepository;
        public RegisterController()
        {
            //studentRepository = new UserRepository();
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

            return View();


        }

    }


}