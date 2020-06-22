using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Boss;
using Dal.Bossdal;
using Model;
using System.Data;
using ErpWebApi.Model;
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
        public int Add(Userinfo u)
        {
            return _dal.Add(u);
        }

        public int Del(int id)
        {
            return _dal.Del(id);
        }

        public DataTable Retrieve(string name)
        {
            return _dal.Retrieve(name);
        }
        [HttpGet]
        public HttpResposeMessage1 Show()
        {
            List<Userinfo> list = _dal.Show();
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

        public int Upt(int id, string Uname, string Upass, string Uphone, string Uemail, int Uage, bool Usex, decimal Salary)
        {
            return _dal.Upt(id, Uname, Upass, Uphone, Uemail, Uage, Usex, Salary);
        }
    }
}
