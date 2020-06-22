using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpWebApi.Model
{
    public class HttpResposeMessage
    {

        public int Code { get; set; }//字符
        public string Msg { get; set; }//消息
        public int Count { get; set; }//数量

        public List<Goods> Data { get; set; }//数据

    }
}
