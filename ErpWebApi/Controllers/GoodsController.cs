using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dal;
using Model;
using System.Data;

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
       


        public int Add(Goods g, string name, int id, int num)
        {
            return _dal.Add(g, name, id, num);
        }

        public int Del(int id, int num)
        {
            return _dal.Del(id, num);
        }

        public DataTable Retrieve(string name)
        {
            return _dal.Retrieve(name);
        }

        public List<Goods> Show()
        {
            return _dal.Show();
        }

        public int Upt(int id, string name, DateTime scdate, int bz, string zx, int phone, int sum)
        {
            return _dal.Upt(id, name, scdate, bz, zx, phone, sum);
        }
    }
}
