using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentFascade
    {
        public IDataReader GetByName(string name)
        {

            string cmdText = "SELECT * FROM Student WHERE [Name]=@pName";

            DbHelper helper = new DbHelper();
            helper.ExecuteReader(cmdText);

            throw new NotImplementedException("");

            //引入EF之后DAL层消失，ORM超额完成DAL任务

        }





    }
}
