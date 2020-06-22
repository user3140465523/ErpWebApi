using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dal;
using Model;
using System.Data;
using ErpWebApi.Model;

namespace ErpWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private IGoodsdal _dal;
        public GoodsController(IGoodsdal dal)
        {
            _dal = dal;

        }
       


        public int Add(Goods g, string name, int num)
        {
            return _dal.Add(g, name, num);
        }

        public int Del(int id, int num)
        {
            return _dal.Del(id, num);
        }
        
        public DataTable Retrieve(string name)
        {
            return _dal.Retrieve(name);
        }
        [HttpGet]
        public HttpResposeMessage Show()
        {
            List<Goods> list = _dal.Show();
            if (list!= null)
            {
                HttpResposeMessage message = new HttpResposeMessage()
                {
                    Code = 0,
                    Count = list.Count(),
                    Msg = "查询成功",
                    Data = list

                };

                return message;
            }
            else
            {
                HttpResposeMessage message = new HttpResposeMessage()
                {
                    Code = 1,
                    Count = list.Count(),
                    Msg = "查询失败",
                    Data = list

                };

                return message;
            }
        }

        public int Upt(int id, string name, DateTime scdate, int bz, string zx, int phone, int sum)
        {
            return _dal.Upt(id, name, scdate, bz, zx, phone, sum);
        }
    }
}
