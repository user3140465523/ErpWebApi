using System;
using System.Collections.Generic;
using System.Text;
using Model.Boss;
namespace Dal.Bossdal
{
    public class Producedal : IProducedal
    {
        public int Add(Produce u)
        {
            string Adds = $"insert into Produce Values({u.Proid},'{u.Proname}','{u.Proscdate}',{u.Pronum},'{u.Proyj}')";
            return DBHelper.ExecuteNonQuery(Adds);
        }

        public List<Produce> Show()
        {
            string shows = "select * from Produce";
            return DBHelper.GetList<Produce>(shows);
        }
    }
}
