using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public string Introduction { get; set; }
        public int Password { get; set; }
        public User InvitedBy { get; set; }
        public string InviteCode { get; set; }
        public int BCredit { get; private set; }

        //public void Register() 
        //{
        //    InvitedBy.BCredit += 10;
        //}
    }
}
