using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace Dal.Logindal
{
   public interface IUserInfoDAL
    {
        Userinfo Login(Userinfo info);
        int LoginAdd(Userinfo info);
    }
}
