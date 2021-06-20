using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Repositories;

namespace RazorPages.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private UserRepository userRepository;
        public RegisterModel()
        {
            userRepository = new UserRepository();
        }

        public Entities.User NewUser { get; set; }
        public string VerifyPassword { get; set; }

        //[RegularExpression(@"[1-9]\d{4,}", ErrorMessage = "QQ��ʽ���Ծ�")]
        //public string QQ { get; set; }
        //Ϊ������
        [QQ]
        //[Display(Name ="��ѶQQ")]    //ָ��Name
        public string QQ { get; set; }
        


        public void OnGet()
        {

        }
        public void OnPost() 
        {
            //Entities.User invitedBy = userRepository.GetByName(NewUser.InvitedBy.Name);
            //if (invitedBy==null)
            //{

            //}
            //if (invitedBy.InviteCode!=NewUser.InvitedBy.InviteCode )
            //{

            //}
            //NewUser.InvitedBy = invitedBy;
            //NewUser.Register();
            //userRepository.Save(NewUser);
        }
    }
}
