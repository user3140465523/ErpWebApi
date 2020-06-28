using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Boss
{
   public class Produce
    {
        public int Proid { get; set; }//生产id

        public string Proname { get; set; }//生产名称
        public DateTime Proscdate { get; set; }//生产日期
        public int Pronum { get; set; }//生产数量
        public DateTime Proyj { get; set; }//生产完成预计

    }
}
