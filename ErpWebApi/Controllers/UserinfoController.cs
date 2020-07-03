using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ErpWebApi.Model;
using Model.Boss;
using Dal.Bossdal;
using System.Data;


namespace ErpWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserinfoController : ControllerBase
    {
        private IUserinfodal _dal;
        public UserinfoController(IUserinfodal dal)
        {
            _dal = dal;
        }
        [HttpPost]
        public int Add([FromForm]Userinfo u)
        {
            return _dal.Add(u);
        }

        public int Del([FromBody] int Uid)
        {
            return _dal.Del(Uid);
        }

        public DataTable Retrieve(string name)
        {
            return _dal.Retrieve(name);
        }
        [HttpGet]
        public HttpResposeMessage1 Show()
        {
            List<Userinfo> list =_dal.Show();
            if (list != null)
            {
                HttpResposeMessage1 message = new HttpResposeMessage1()
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
                HttpResposeMessage1 message = new HttpResposeMessage1()
                {
                    Code = 1,
                    Count = list.Count(),
                    Msg = "查询失败",
                    Data = list

                };

                return message;
            }

        }
        [HttpPut]
        [Route("Upt")]
        public int Upt(Userinfo u)
        {
            return _dal.Upt(u);
        }

    }
}
