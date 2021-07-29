using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Entities
{
    public class Problem:Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishTime { get; set; }
        public int? Rrward { get; set; }
        public ProblemStatus Status { get; set; }


    }
    public enum  ProblemStatus
    {
        [Description("已酬谢")]
        Rewarded=1,
        [Description("已撤销")]
        canceled=2,
        [Description("协助中")]
        Inprocess=4,


    }
}
