using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Entities
{
    //[Table("Register")]
    //[Index("CreateTime",IsUnique =true)]
    public class User : Entity
    {
        //[Column("UserName")]
        //[MaxLength(256)]
        //[Key]
        public string Name { get; set; }
        public string Introduction { get; set; }
        public int Password { get; set; }
        public bool IsMale { get; set; }

        public User InvitedBy { get; set; }
        public string InviteCode { get; set; }
        public int BCredit { get;  set; }

        //[NotMapped]
        public int FailedTry { get; set; }
        public DateTime CreateTime { get; set; }

        //public void Register() 
        //{
        //    InvitedBy.BCredit += 10;
        //}
    }
}
