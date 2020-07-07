using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Logindal;
using ErpWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Login;

namespace ErpWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Userdal _userinfo = null;
        private Userdal UserinfoDal
        {
            get
            {
                if (_userinfo == null)
                {
                    _userinfo = new Userdal();
                }
                return _userinfo;
            }
        }
        #region 登录
        [HttpGet]
        public object Logins(string Uname, string Upass)
        {
            var result = UserinfoDal.Login(Uname, Upass);
            return result;
        }
        #endregion

        #region 给QQ邮箱发验证码
        [HttpGet]
        public string QQEmailCode(string email)
        {
            return UserinfoDal.QQEmailCode(email);
        }
        #endregion
        #region 修改密码
        public object UptUserInfo(string upass, string uemail, string uname)
        {

            return UserinfoDal.UptUserInfo(upass, uemail, uname);
        }
        #endregion
        #region 登录日志

        public int LoginLogsAdd([FromForm] LoginLogs info)
        {
            var result = UserinfoDal.LoginLogsAdd(info);
            return result;
        }
        #endregion
        #region 显示日志
        public httpResponseMessage3 LoginLogsShow()
        {
            List<LoginLogs> list = UserinfoDal.LoginLogsShow();


            httpResponseMessage3 message = new httpResponseMessage3()
            {
                Code = 0,
                Count = list.Count(),
                Msg = "查询成功",
                Data = list

            };

            return message;
        }
        #endregion
    }
}
