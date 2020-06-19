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


        int Del(int id);


        int Upt(int id,string Uname,string Upass, string Uphone, string Uemail, int Uage, bool Usex,decimal Salary);


        DataTable Retrieve(string name);
    }
}
