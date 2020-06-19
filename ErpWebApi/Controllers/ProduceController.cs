using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Boss;
using Dal.Bossdal;

namespace ErpWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProduceController : ControllerBase
    {
        private IProducedal _dal;
        public ProduceController(IProducedal dal)
        {
            _dal = dal;

        }
        public int Add(Produce u)
        {
            return _dal.Add(u);
        }

        public List<Produce> Show(int num)
        {
            return _dal.Show(num);
        }
    }
}
