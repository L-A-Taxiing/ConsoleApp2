using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Filters;
using RazorPages.Repositories;

namespace RazorPages.Pages.Log
{
    [BindProperties]
    [AutoModelValidation]
    //[ContextPreRequest]
    public class OnModel : PageModel
    {
        private UserRepository userRepository;
        public OnModel()
        {
            userRepository = new UserRepository();
        }
        public string Name { get; set; }
        public int Password { get; set; }
        public bool RememberMe { get; set; }
        public string Captcha { get; set; }
       

        public void OnGet()
        {
            RememberMe = true;
            ViewData["HasLogOn"] = Request.Cookies[Keys.UserId];
            //3. ��TempData��ȡ��Error��Ϣ
            Dictionary<string, string> errors = TempData[Keys.ErrorInfo] as Dictionary<string, string>;
            if (errors != null)
            {
                //4. ��Error��Ϣ��ӵ�ModelState  foreach (var item in errors)
                foreach (var item in errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

            }

        }
        public IActionResult OnPost() 
        {
            //if (!ModelState.IsValid)
            //{
            //    return;
            //}

            Entities.User user = userRepository.GetByName(Name);
            if (user==null)
            {
                //�û���������
                ModelState.AddModelError(nameof(Name), "�û���������");
                //1.��ModelState����ȡError��Ϣ
                Dictionary<string, string> errors =
                    ModelState.Where(m => m.Value.Errors.Any())
                        .ToDictionary(
                            m => m.Key,
                            m => m.Value.Errors
                                .Select(s => s.ErrorMessage)
                                .FirstOrDefault(s => s != null));

                //2. ��Error��Ϣ��ŵ�TempData
                TempData[Keys.ErrorInfo] = errors;
                return RedirectToPage();
            }
            if (user.Password!=Password)
            {
                //�û��������벻��ȷ
                ModelState.AddModelError(nameof(Password), "�û��������벻��ȷ");
                //1. ��ModelState����ȡError��Ϣ
                Dictionary<string, string> errors =
                    ModelState.Where(m => m.Value.Errors.Any())
                        .ToDictionary(
                            m => m.Key,
                            m => m.Value.Errors
                                .Select(s => s.ErrorMessage)
                                .FirstOrDefault(s => s != null));

                //////2. ��Error��Ϣ��ŵ�TempData
                TempData[Keys.ErrorInfo] = errors;
                return RedirectToPage();
            }
          


            CookieOptions options = new CookieOptions();
            if (RememberMe)
            {
                options.Expires = DateTime.Now.AddDays(15);
            }//else Expire after session


            Response.Cookies.Append(Keys.UserId, user.Id.ToString(),options);

            //ViewData["HasLogOn"] = true;   //���д������Post�ﲻ�ᱻ����
            return RedirectToPage("/Index");

        }
    }
}
