using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model;

namespace Dal
{
    public interface IGoodsdal
    {
        int Add(Goods g, string name, int id, int num);


        List<Goods> Show();


        int Del(int id, int num);


        int Upt(int id, string name, DateTime scdate, int bz, string zx, int phone, int sum);


        DataTable Retrieve(string name);

    }
}
