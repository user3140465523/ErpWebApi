using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Login
{
  public  class LoginLogs
    {
        public int Id { get; set; }
        public string IP { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserAgent { get; set; }
    }
}
