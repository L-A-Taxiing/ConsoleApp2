using SRV.ServiceInterface;
using SRV.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockService
{
    public class ArticleService : IArticleService
    {
        public int Publish(NewModel model, int CurrentUserId)
        {
            return 1;
        }
        public SingleModel GetById(int id)
        {

            return new SingleModel
            {

                Title = "我是Title",
                Body = "我是Body"

            };
        
        
        
        
        
        
        }
    }
}
