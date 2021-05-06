using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.OO
{
    class Comment
    {
        //一个评论必须有一个它所评论的文章
        public Article Article { get; set; }

        //每个文章和评论都有一个评价
        public Appraise Appraise { get; set; }

    }
}
