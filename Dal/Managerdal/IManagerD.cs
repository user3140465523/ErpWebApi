using Model.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Managerdal
{
    public interface IManagerD
    {
        List<Addmoney> Show(string uname);
        int Upadte(int aid);

    }
}

