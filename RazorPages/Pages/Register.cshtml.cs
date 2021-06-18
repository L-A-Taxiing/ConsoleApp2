using System;
using System.Collections.Generic;
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
        public Entities.User NewUser { get; set; }
        public string VerifyPassword { get; set; }

        private UserRepository userRepository;
        public RegisterModel()
        {
            userRepository = new UserRepository();
        }

        public void OnGet()
        {

        }
        public void OnPost() 
        {
            Entities.User invitedBy = userRepository.GetByName(NewUser.InvitedBy.Name);
            //if (invitedBy==null)
            //{

            //}
            //if (invitedBy.InviteCode!=NewUser.InvitedBy.InviteCode )
            //{

            //}
            NewUser.InvitedBy = invitedBy;
            NewUser.Register();
            userRepository.Save(NewUser);
        }
    }
}
