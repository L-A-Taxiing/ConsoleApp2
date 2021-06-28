using Microsoft.AspNetCore.Mvc;
using RazorPages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.ViewComponents
{
    public class _Keywords : ViewComponent
    {
        public IViewComponentResult Invoke(int amount/*,int skip*/)
        {

            IList<Keyword> keywords = new List<Keyword>
            {
                new Keyword{Id=1,Name="C#"},
                new Keyword{Id=2,Name="SQL"},
                new Keyword{Id=3,Name="JavaScript"}

        };


            return View(keywords.Take(amount).ToList());
            //return View(keywords.Skip(skip).Take(amount).ToList());
            //return View("/Pages/Components/_Keywords.cshtml");
        }

    }
}
