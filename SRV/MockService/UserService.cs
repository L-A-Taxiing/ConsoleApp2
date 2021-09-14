using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRV.MockService
{
    public class UserService : IUserService
    {
        public int Register(RegisterModel model)
        {
            return 986;
        }
        public UserModel GetByName(string Name)
        {
            throw new NotImplementedException();
        }
        public string GetPwdById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
