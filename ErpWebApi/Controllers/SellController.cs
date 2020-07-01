using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Selldal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Sell;
using Newtonsoft.Json;

namespace ErpWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        private ISellDal dal;
        public SellController(ISellDal _dal)
        {
            dal = _dal;
        }
        //显示销量

        public List<StatisModel> GetStatiss()
        {
            List<StatisModel> list = dal.GetStatis();
            return list;
        }
        //查询商品
        public string SearchGoods(int id = 0, string name = "") 
        {
            List<GoodsModel> goods = dal.SearchGoods(id, name);
            Dictionary<string, object> obj = new Dictionary<string, object>();

            //前台通过key值获得对应的value值
            obj.Add("code", 0);
            obj.Add("msg", "");
            obj.Add("count", goods.Count);
            obj.Add("data", goods);
            return JsonConvert.SerializeObject(obj);
        }
        //申请加薪
        public int AddMoneys(AddMoneyModel model)
        {
            return dal.AddMoney(model);
        }
        //删除商品信息
        public int GoodsDel(GoodsModel model)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            return dal.GoodsDel(model.Gid);
        }
        //显示商品
        public string GoodsShow(int page,int limit)
        {
            List<GoodsModel> goods = dal.ShowGoods();
            int num = goods.Count;
            goods = goods.Skip((page - 1) * limit).Take(limit).ToList();
            Dictionary<string, object> obj = new Dictionary<string, object>();

            //前台通过key值获得对应的value值
            obj.Add("code", 0);
            obj.Add("msg", "");
            obj.Add("count", num);
            obj.Add("data", goods);
            return JsonConvert.SerializeObject(obj);
        }
        //修改库存(减去)
        public int GoodsUpt(int gid, int num)
        {
            return dal.GoodsUpt(gid, num);
        }
        //修改销量 
        public int StatisUpt(int stid, int num)
        {
            return dal.StatisUpt(stid, num);
        }
        
    }
}