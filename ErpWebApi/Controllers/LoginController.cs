using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Dal.Logindal;

namespace ErpWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserInfoDAL _dal;
        public LoginController(IUserInfoDAL dal) {
            _dal= dal ;
        }
        public Userinfo Login(Userinfo info)
        {
            return _dal.Login(info);
        }

        public int LoginAdd(Userinfo info)
        {
            return _dal.LoginAdd(info);
        }
    }
}
