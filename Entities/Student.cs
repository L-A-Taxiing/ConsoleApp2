using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Student
    {
        public Student InvitedBy { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public double Score { get; internal set; }

        public string ConfirmPassword { get; set; }//不应该映射到数据库

        public void Register()
        {



        }

    }
}
