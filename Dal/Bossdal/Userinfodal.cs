using Model.Boss;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dal.Bossdal
{
    public class Userinfodal : IUserinfodal
    {
        public int Add(Userinfo u)
        {
          string Adds= $"insert into  Userinfo Values ('{u.Uname}','{u.Upass}','{u.Uphone}','{u.Uemail}',{u.Uage},'{u.Usex}',{u.Salary},{3})";
            return DBHelper.ExecuteNonQuery(Adds); 
        }

        public int Del(int Uid)
        {
            string dels = $"delete from Userinfo where Uid={Uid}";

            return DBHelper.ExecuteNonQuery(dels);
        }

        public DataTable Retrieve(string name)
        {
            string rets = $"select * from Userinfo where like name={name} ";
            return DBHelper.GetDataTable(rets);
        }

        public List<Userinfo> Show()
        {
            string shows = "select * from Userinfo";
            return DBHelper.GetList<Userinfo>(shows);
        }

        public int Upt(Userinfo u)
        {
            string upts = $"update Userinfo set Uname='{u.Uname}',Upass='{u.Upass}',Uphone='{u.Uphone}',Uemail='{u.Uemail}',Uage={u.Uage},Usex={u.Usex},Salary='{u.Salary}' where Uid={u.Uid}";
            return DBHelper.ExecuteNonQuery(upts);
        }

       
    }
}
