using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Userinfo
    {
        public int Uid { get; set; }//用户id
        public string Uname { get; set; }//用户姓名
        public string Upass { get; set; }//用户密码
        public string Uphone { get; set; }//用户手机
        public string Uemail { get; set; }//用户邮箱
        public int Uage { get; set; }//用户年龄
        public int Usex { get; set; }//用户性别
        public decimal Salary { get; set; }//用户工资
        public int Rid { get; set; }//外键
    }
}
