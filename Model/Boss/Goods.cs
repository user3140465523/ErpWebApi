using System;

namespace Model
{
    public class Goods
    {
        public int Gid { get; set; } //商品id
        public string Gname { get; set; } //商品名字
        public DateTime Gscdata { get; set; }//商品生产日期
        public string Gbz { get; set; }      //商品保质期
        public string Gzxbz { get; set; }  //商品执行编号
        public string Gphone { get; set; }   //商家联系电话
        public int Gnum { get; set; }  //库存数
    }
}
