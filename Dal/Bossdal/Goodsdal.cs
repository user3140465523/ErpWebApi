using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dal
{
    public class Goodsdal : IGoodsdal
    {
        public int Add(Goods g)
        {
            int names = (int)DBHelper.GetDataTable($"select count(1) from Goods where Gname='{g.Gname}'").Rows[0][0];
            
            if(names!=0)
            {
                string updates = $"update Goods set Gnum=Gnum+{g.Gnum} where Gname='{g.Gname}' ";
                return DBHelper.ExecuteNonQuery(updates);
            }
            else
            {
                string Adds = $"insert into  Goods Values('{g.Gname}','{g.Gscdata}',{g.Gbz},'{g.Gzxbz}','{g.Gphone}',{g.Gnum})";
                return DBHelper.ExecuteNonQuery(Adds);
               
            }
        }

        public int Del(int id)
        {
            string dels = $"delete from Goods where Gid={id}";

            return DBHelper.ExecuteNonQuery(dels);
        }

        public DataTable Retrieve(string name)
        {
            string rets = $"select * from Goods where Gname='{name}'";
            return DBHelper.GetDataTable(rets);
        }

        public List<Goods> Show()
        {
            string shows = "select * from Goods ";
            return DBHelper.GetList<Goods>(shows);
        }

        public int Upt(Goods g)
        {
            string upts = $"update Goods set Gname='{g.Gname}',Gscdate='{g.Gscdata}',Gbz={g.Gbz},Gzxbz='{g.Gzxbz}',Gphone='{g.Gphone}',Gnum={g.Gnum} where Gid={g.Gid}";
            return DBHelper.ExecuteNonQuery(upts);
        }
    }
}
