using System;
using System.Collections.Generic;
using System.Text;
using Model.Login;
namespace Dal.Logindal
{
   public interface IUserdal
    {
        string Login(string Uname, string Upass);
        string QQEmailCode(string email);
        object UptUserInfo(string upass, string uemail, string uname);
        int LoginLogsAdd(LoginLogs info);
        List<LoginLogs> LoginLogsShow();
    }
}
