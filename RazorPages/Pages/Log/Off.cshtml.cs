using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Filters;

namespace RazorPages.Pages.Log
{
    [CloseConnection]
    public class OffModel : PageModel
    {
        //public void OnGet()
        //{
        //    Response.Cookies.Delete(Keys.UserId);//±ÜÃâÊ¹ÓÃ×Ö·û´®³ö´í

        //}

        public IActionResult OnGet()
        {
            Response.Cookies.Delete(Keys.UserId);
            //return RedirectToPage("/Log/On");
            return Redirect(Request.Headers["referer"]);

        
        
        }



    }
}
