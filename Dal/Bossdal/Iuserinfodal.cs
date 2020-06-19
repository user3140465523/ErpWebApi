using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Bossdal
{
    public interface IUserinfodal
    {

        int Add(Userinfo u);


        List<Userinfo> Show();


        int Del(int id);


        int Upt(string Uname, DateTime scdate, int bz, string zx, int phone, int sum);


        DataTable Retrieve(string name);
    }
}
