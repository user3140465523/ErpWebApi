using Model.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpWebApi.Models
{
    public class Responsedata
    {
        public int code { get; set; } = 0;
        public string msg { get; set; }
        public int count { get; set; }
        public List<Addmoney> data { get; set; }
    }
}
