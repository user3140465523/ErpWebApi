using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Model.Manager;

namespace Dal.Managerdal
{
    public class ManagerDal:IManagerD
    {
        public List<Addmoney> Show(string uname)
        {
            string sql = "";
            if (uname==null)
            {
                sql = $"select * from AddMoney as aa join Userinfo as uu on aa.Uid=uu.Uid";
            }
            else
            {
                sql = $"select * from AddMoney as aa join Userinfo as uu on aa.Uid=uu.Uid where uu.Uname like '%"+uname+"%'";
            }
            
            return DBHelper.GetList<Addmoney>(sql);
        }
        public int  Upadte(int aid)
        {
            string shows = $"select * from AddMoney where AddMoney.Aid={aid}";
            var list = DBHelper.GetList<Addmoney>(shows).FirstOrDefault();
            string sql = $"update Userinfo set Salary=Salary+{list.AddMoneys} where Uid={list.Uid}";
            return DBHelper.ExecuteNonQuery(sql);
        }
    }
}