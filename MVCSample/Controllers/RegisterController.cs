using MVCSample.Filters;
using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Repositories;
using BLL.Entities;

//Ctrl alt+w打开watch  ctrl \+E打开ErrorList
namespace MVCSample.Controllers
{
    public class RegisterController : Controller
    {

        private StudentRepository studentRepository;
        public RegisterController()
        {
            studentRepository = new StudentRepository();
        }

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(RegisterModel model)  //不要直接使用entitiy作为model 
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //用户名是否重复
            if (studentRepository.GetByName(model.Name)!=null)
            {
                ModelState.AddModelError("Name", "用户名不能重复");
            }

            Student student = new Student
            {
                Name = model.Name,
                Password = model.Password
            };
            student.Register();
            int id = studentRepository.Save(student);

            return View();


        }

    }


}