using Model;
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
          string Adds= $"insert into  Userinfo Values('{u.Uname}','{u.Upass}','{u.Uphone}','{u.Uemail}','{u.Uage}','{u.Usex}','{u.Salary}')";
            return DBHelper.ExecuteNonQuery(Adds); 
        }

        public int Del(int id)
        {
            string dels = $"select * from Userinfo where id={id}";

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

        public int Upt( int id,string Uname, string Upass, string Uphone, string Uemail, int Uage, bool Usex, decimal Salary)
        {
            string upts = $"update Userinfo set Uname={Uname},Upass={Upass},Uphone={Uphone},Uemail={Uemail},Uage={Uage},Usex={Usex} Salary={Salary}where Gid={id}";
            return DBHelper.ExecuteNonQuery(upts);
        }

       
    }
}
