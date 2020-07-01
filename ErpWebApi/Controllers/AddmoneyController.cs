using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dal.Managerdal;
using Model.Manager;
using ErpWebApi.Models;

namespace ErpWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AddmoneyController : ControllerBase
    {
        private IManagerD _dal;
        public AddmoneyController(IManagerD dal)
        {
            _dal = dal;
        }

        public Responsedata Show(int page, int limit,string uname)
        {
            List<Addmoney> list = _dal.Show(uname);

            if (list != null)
            {
              
                int Num = list.Count;
                list = list.Skip((page - 1) * limit).Take(limit).ToList();
                Responsedata message = new Responsedata()
                {
                    code = 0,
                    count =Num,
                    msg = "查询成功",
                    data = list,

                };
               
                return message;
            }
            else
            {
                Responsedata message = new Responsedata()
                {
                    code = 1,
                    count = list.Count(),
                    msg = "查询失败",
                    data = list

                };

                return message;
            }
        }
        public int Update(int aid)
        {
            return _dal.Upadte(aid);
        }
    }

}

