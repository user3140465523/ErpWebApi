using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Boss;
using Dal.Bossdal;
using ErpWebApi.Model;

namespace ErpWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProduceController : ControllerBase
    {
        private IProducedal _dal;
        public ProduceController(IProducedal dal)
        {
            _dal = dal;

        }
        public int Add(Produce u)
        {
            return _dal.Add(u);
        }

        public HttpResposeMessage2 Show(int num)
        {
            List<Produce> list = _dal.Show(num);
          
          
                HttpResposeMessage2 message = new HttpResposeMessage2()
                {
                    Code = 0,
                    Count = list.Count(),
                    Msg = "查询成功",
                    Data = list

                };

                return message;
            
        }
    }
}
