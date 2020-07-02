using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Model;

namespace Dal
{
    public interface IGoodsdal
    {
        int Add(Goods g);


        List<Goods> Show();


        int Del(int id);


        int Upt(Goods g);


        DataTable Retrieve(string name);

    }
}
