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
            string Adds = $"insert into Produce Values('{u.Proname}','{u.Pronum}','{u.Proscdate}','{u.Proyj}',)";
            return DBHelper.ExecuteNonQuery(Adds);
        }

        public List<Produce> Show(int num)
        {
            string shows = "select * from Produce";
            return DBHelper.GetList<Produce>(shows);
        }
    }
}
