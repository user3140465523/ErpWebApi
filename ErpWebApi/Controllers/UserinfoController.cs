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

        public List<Userinfo> Show()
        {
            return _dal.Show();
        }

        public int Upt(int id, string Uname, string Upass, string Uphone, string Uemail, int Uage, bool Usex, decimal Salary)
        {
            return _dal.Upt(id, Uname, Upass, Uphone, Uemail, Uage, Usex, Salary);
        }
    }
}
