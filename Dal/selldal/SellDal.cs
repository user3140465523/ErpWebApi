using Model.Sell;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Selldal
{
    public class SellDal:ISellDal
    {
        //查询商品
        public List<GoodsModel> SearchGoods(int id, string name)
        {
            string sql = "";
            if (id == 0 && name == null)
            {
                sql = "select * from Goods";
                return DBHelper.GetList<GoodsModel>(sql);
            }
            else if (name == null)
            {
                sql = "select * from Goods where Gid=" + id + "";
                return DBHelper.GetList<GoodsModel>(sql);
            }
            else if (id == 0)
            {
                sql = "select * from Goods where Gname='" + name + "'";
                return DBHelper.GetList<GoodsModel>(sql);
            }
            else
            {
                sql = "select * from Goods where Gid=" + id + " and Gname='" + name + "'";
                return DBHelper.GetList<GoodsModel>(sql);
            }
        }
        //加薪申请
        public int AddMoney(AddMoneyModel model)
        {
            string sql = $"insert into AddMoney values('{model.RoleName}','{model.AddMoneys}','{model.Remark}',{model.Uid})";
            return DBHelper.ExecuteNonQuery(sql);
        }
        //销量报表
        public List<StatisModel> GetStatis()
        {
            string sql = "select s.Stid,s.Stsum,s.Sdate from Statisticss s group by s.Stsum,s.Sdate,s.Stid";
            return DBHelper.GetList<StatisModel>(sql);
        }
        //删除商品
        public int GoodsDel(int gid)
        {
            string sql = "delete from Goods where Gid=" + gid + "";
            return DBHelper.ExecuteNonQuery(sql);
        }
        //显示商品
        public List<GoodsModel> ShowGoods()
        {
            string sql = "select * from Goods";
            return DBHelper.GetList<GoodsModel>(sql);
        }
        //修改库存数量
        public int GoodsUpt(int gid, int num)
        {
            string sql = "update Goods set Gnum=Gnum-" + num + " where Gid=" + gid + "";
            return DBHelper.ExecuteNonQuery(sql);
        }
        //修改员工销量
        public int StatisUpt(int stid, int num)
        {
            string sql = "update Statisticss set Stsum=Stsum+" + num + " where Stid=" + stid + "";
            return DBHelper.ExecuteNonQuery(sql);
        }
         
    }
}
