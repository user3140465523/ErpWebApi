using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Login
{
 public   class Userinfo
    {
        /// <summary>
        ///Id
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Uname { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Upass { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Uphone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Uemail { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Uage { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Usex { get; set; }
        public decimal salary { get; set; }
        public int Rid { get; set; }
    }
}
