using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Entities
{
    public class Message:Entity
    {
        public bool Selected { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string Content { get; set; }
        public bool HasRead { get; set; }
        public bool Read() 
        {
            HasRead = true;
            return HasRead;
        }
    }
}
