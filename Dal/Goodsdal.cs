﻿using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dal
{
    public class Goodsdal : IGoodsdal
    {
        public int Add(Goods g, string name, int id, int num)
        {
            object names = DBHelper.GetDataTable($" select * from Goods like {name}=Gname where {id}=Gid");
            if (Convert.ToString(names) != "")
            {
                string updates = $"update Goods set num={num}+num where {id}=Gid";
                return DBHelper.ExecuteNonQuery(updates);
            }
            else
            {
                string Adds = $"insert into from Goods Values('{g.Gname}','{g.Gscdata}','{g.Gbz}','{g.Gzxbz}','{g.Gphone}','{g.num}')";
                return DBHelper.ExecuteNonQuery(Adds);

            }
        }

        public int Del(int id, int num)
        {
            string dels = $"update Goods set num=num-{num} where Gid={id}";

            return DBHelper.ExecuteNonQuery(dels);
        }

        public DataTable Retrieve(string name)
        {
            string rets = $"select * from Goods where like name={name} ";
            return DBHelper.GetDataTable(rets);
        }

        public List<Goods> Show()
        {
            string shows = "select * from Goods ";
            return DBHelper.GetList<Goods>(shows);
        }

        public int Upt(int id, string name, DateTime scdate, int bz, string zx, int phone, int sum)
        {
            string upts = $"update Goods set Gname={name},Gscdate={scdate},Gbz={bz},Gzxbz={zx},Gphone={phone},Gsum={sum} where Gid={id}";
            return DBHelper.ExecuteNonQuery(upts);
        }
    }
}
