using Model.Sell;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Selldal
{
    public interface ISellDal
    {
        List<GoodsModel> SearchGoods(int id, string name);
        int AddMoney(AddMoneyModel model);
        List<StatisModel> GetStatis();
        int GoodsDel(int gid);
        List<GoodsModel> ShowGoods();
        int GoodsUpt(int gid, int num);
        int StatisUpt(int stid, int num);
 
    }
}
