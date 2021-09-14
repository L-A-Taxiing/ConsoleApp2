using BLL.Entities;
using BLL.Repositories;
using SRV.ServiceInterface;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class UserService : IUserService
    {
        private UserRepository userRepository;
        public UserService()
        {
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
        }

        public UserModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public string GetPwdById(int Id)
        {
            throw new NotImplementedException();
        }
        
        private string MD5Crypt(string source)
        {
            byte[] bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(source));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));  //x2占两个位置用0代替
            }
            return /*Encoding.UTF8.GetString(bytes);*/sb.ToString();

        }

        public int Register(RegisterModel model)
        {
            User user = new User
            {
                Name = model.Name,
                Password = MD5Crypt(model.Password)
            };
            user.Register();
            int id = userRepository.Save(user);
            return user.Id;
        }
    }
}
