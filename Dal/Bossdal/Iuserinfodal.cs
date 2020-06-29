using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace Dal.Bossdal
{
    public interface IUserinfodal
    {

        int Add(Userinfo u);


        List<Userinfo> Show();


        int Del(int Uid);


        int Upt(Userinfo u);


        DataTable Retrieve(string name);
    }
}
