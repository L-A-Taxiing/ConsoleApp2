using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Entities
{
    public class Email:Entity
    {
        public string Address { get; set; }
        public User Owner { get; set; }
    }
}
