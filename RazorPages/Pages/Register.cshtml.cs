using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Filters;
using RazorPages.Repositories;

namespace RazorPages.Pages
{
    [BindProperties]
    [AutoModelValidation]
    public class RegisterModel : PageModel
    {
        private UserRepository userRepository;
        public RegisterModel()
        {
            userRepository = new UserRepository();
        }

        public Entities.User NewUser { get; set; }
        public int VerifyPassword { get; set; }

        //[RegularExpression(@"[1-9]\d{4,}", ErrorMessage = "QQ格式不对劲")]
        //public string QQ { get; set; }
        //为了重用
        [QQ]
        //[Display(Name ="腾讯QQ")]    //指定Name
        public string QQ { get; set; }
        


        public void OnGet()
        {
           
        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Entities.User invitedBy = userRepository.GetByName(NewUser.InvitedBy.Name);
            //if (invitedBy==null)
            //{

            //}
            //if (invitedBy.InviteCode!=NewUser.InvitedBy.InviteCode )
            //{

            //}
            NewUser.InvitedBy = invitedBy;
            //NewUser.Register();
            if (userRepository.GetByName(NewUser.Name)!=null)
            {
                ModelState.AddModelError("NewUser.Name", "用户名已经被使用");
                return Page();
            }
            else
            {
                userRepository.Save(NewUser);

            }
            Response.Cookies.Append(nameof(NewUser.Name), NewUser.Name);
            Response.Cookies.Append(nameof(NewUser.Password),NewUser.Password.ToString());
            //return RedirectToPage("/Log/On");
            return RedirectToPage("/Log/On");
        }
    }
}

