using Dal.Ecio_Admin;
using Model.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Dal.Logindal
{
   public class Userdal:IUserdal
    {
        SqlHelper sqlhelper = new SqlHelper();
        //public List<LoginLogs> loginLogs { get; set; }
        #region 登录
        public string Login(string Uname, string Upass)
        {
            var userinfo = $@"select [Uid]
      ,[Uname]
      ,[Upass]
      ,[Uphone]
      ,[Uemail]
      ,[Uage]
      ,[Usex]
      ,[salary]
      ,[Rid] from UserInfo where Uname='{Uname}'and Upass='{Upass}'";
            DataTable da = DBHelper.GetDataTable(userinfo);
            if (da != null && da.Rows != null && da.Rows.Count > 0)
            {
                var list = UtilityHelper.ToDataList<Userinfo>(da);
                return JsonConvert.SerializeObject(new { code = 100, msg = "登录成功", data = list });

            }
            else
            {
                return JsonConvert.SerializeObject(new { code = 500, msg = "登录失败，账号或密码错误!" });
            }
        }
        #endregion
        #region 登录日志
        SqlHelper sqlHelper = new SqlHelper();
        public int LoginLogsAdd(LoginLogs info)
        
        
        
        {
            string LogiAdd = $"insert into LoginLogs values('{info.IP}','{DateTime.Now}','{info.UserAgent}')";
            return sqlHelper.ExecuteNonQuery(LogiAdd);
        }

        #endregion
        #region 显示日志
        public List<LoginLogs> LoginLogsShow()
        {
            string LogiShow = $@"SELECT [Id]
      ,[IP]
      ,[CreateTime]
      ,[UserAgent]
  FROM[dbo].[LoginLogs]";
            return DBHelper.GetList<LoginLogs>(LogiShow);
        }
        #endregion
        #region 邮箱发送验证码
        /// <summary>
        /// 邮箱绑定
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string QQEmailCode(string email)
        {
            int randNum;
            char code;
            string randomcode = string.Empty;//随机验证码
            //生成6位数验证码
            for (int i = 0; i < 6; i++)
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();//生成字节数组
                int seed = BitConverter.ToInt32(buffer, 0);//利用BitConvert方法把字节数组转换为整数
                Random random = new Random(seed);
                randNum = random.Next();
                code = (char)('0' + (char)(randNum % 10));//随机数字
                randomcode += code.ToString();
            }
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("2113312023@qq.com", "【天体ERP平台】");//发件人邮箱地址
            mail.To.Add(new MailAddress(email));//收件人邮箱地址
            mail.Subject = "欢迎您登录【ERP操作管理系统】";//设置邮件标题
            mail.SubjectEncoding = Encoding.UTF8;//设置标题编码
            mail.Body = "【ERP】官方发送。\r\n\r\n您的验证码为:" + randomcode;//邮件正题
            mail.BodyEncoding = Encoding.UTF8;//正文编码    
            mail.Priority = MailPriority.High;//设置最高优先级

            SmtpClient client = new SmtpClient();//设置QQ邮箱的传输协议
            client.Host = "smtp.qq.com";//QQ邮箱
            client.Port = 587;//设置QQ邮箱端口
            client.EnableSsl = true;//使用安全加密ssl连接
            client.DeliveryMethod = SmtpDeliveryMethod.Network;//通过网络发送电子邮件到SMTP服务器
            client.Credentials = new NetworkCredential("2113312023@qq.com", "dwcfswiqucdmbche");//发件人邮箱和授权码
            //发送邮件
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); //异常处理机制 显示报错信息
            }
            return randomcode;
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="upass"></param>
        /// <param name="uemail"></param>
        /// <param name="email"></param>
        /// <param name="emai"></param>
        /// <returns></returns>
        public object UptUserInfo(string upass, string uemail, string uname)
        {
            string sql = $"	 update Userinfo set Upass='{upass}' where Uemail='{uemail}'and Uname='{uname}'";
            return DBHelper.ExecuteNonQuery(sql);
        }

        #endregion
    }
}
