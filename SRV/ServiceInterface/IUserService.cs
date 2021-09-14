using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ServiceInterface
{
    public interface IUserService
    {
        int Register(RegisterModel model);
        string GetPwdById(int Id);
        //UserModel GetByName(string name);
        //bool GetByName(string Name, out string pwd);
        UserModel GetByName(string name);
    }
}
