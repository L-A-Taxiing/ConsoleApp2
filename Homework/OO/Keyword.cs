using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.OO
{
    class Keyword
    {
        //一个关键字可以对应多篇文章
        public IList<Article> Articles { get; set; }
        public string Name { get; internal set; }
    }
}
