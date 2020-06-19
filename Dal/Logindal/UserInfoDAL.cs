using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dal.Logindal
{
    public class UserInfoDAL : IUserInfoDAL
    {
        public Userinfo Login(Userinfo info)
        {
            string sql = $"select *from Userinfo where Uname ='{info.Uname}'and Upass='{info.Upass}'";
            return DBHelper.GetList<Userinfo>(sql).FirstOrDefault();
        }

        public int LoginAdd(Userinfo info)
        {
            string Adds = $"insert into Userinfo values('{info.Uname}','{info.Upass}','{info.Uphone}','{info.Uemail}','{info.Uage}','{info.Usex}','{info.Salary}','{info.Rid}') ";
            return DBHelper.ExecuteNonQuery(Adds);
            
        }
    }
}
