using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.Design;

namespace Dal.Logindal
{
    public class UserInfoDAL : IUserInfoDAL
    {
        public Userinfo Login(Userinfo info)
        {
            var cx = $"select count(*) from Userinfo where (Uname={info.Uname}and Upass={info.Upass}) ";
            if(cx!="")
            {
                return DBHelper.GetList<Userinfo>(cx).FirstOrDefault();
            }
            else
            {
                string sql= $"select count(*) from zhucebiao where (Uname={info.Uname}and Upass={info.Upass}) ";
                return DBHelper.GetList<Userinfo>(sql).FirstOrDefault();

            }
           
           

            
        }

        public int LoginAdd(Userinfo info)
        {
            string Adds = $"insert into Userinfo values('{info.Uname}','{info.Upass}','{info.Uphone}','{info.Uemail}','{info.Uage}','{info.Usex}','{info.Rid}') ";
            return DBHelper.ExecuteNonQuery(Adds);
            
        }
    }
}
