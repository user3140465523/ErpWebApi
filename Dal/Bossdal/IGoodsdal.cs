using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model;

namespace Dal
{
    public interface IGoodsdal
    {
        int Add(Goods g, string name, int num);


        List<Goods> Show();


        int Del(int id);


        int Upt(int id, string Gname, DateTime Gscdate, int Gbz, string Gzxbz, int Gphone, int Gsum);


        DataTable Retrieve(string name);

    }
}
