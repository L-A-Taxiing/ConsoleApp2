using MVCSample.Models.Article;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockService
{
    public class ArticleService : IArticleService
    {
        public void Publish(NewModel model, int CurrentUserId)
        {
            throw new NotImplementedException();
        }
    }
}
