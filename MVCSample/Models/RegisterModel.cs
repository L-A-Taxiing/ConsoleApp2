using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Models
{
    [Serializable]
    public class RegisterModel
    {
        [Required(ErrorMessage ="用戶名不能為空")]
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }

        [Display(Name = "性别")]
        public bool? IsMale { get; set; }


        public IList<RestItem> Rest { get; set; }

        public int BirthMonth { get; set; }

        public Hobbies Hobbies { get; set; }

        public IEnumerable<SelectListItem> Keywords { get; set; }

        
    }

    
    public class RestItem
    {
        public bool Selected { get; set; }
        public DayOfWeek DayOfWeek { get; set; }


    }

    public enum Hobbies
    {
        [Display(Name ="篮球")]
        BasketBall,

        [Display(Name ="足球")]
        FootBall,

        [Display(Name ="乒乓")]
        Ping_Pong
    }
}