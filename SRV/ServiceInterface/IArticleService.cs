using SRV.ViewModel.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRV.ServiceInterface
{
    public interface IArticleService
    {

         int Publish(NewModel model, int CurrentUserId);//接口不需要访问修饰符
         SingleModel GetById(int id);
    }
}
