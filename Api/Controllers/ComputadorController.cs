using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll.Interface;
using Bll.Implementation;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ComputadorController : Controller
    {
        IComputadorBll PcBLL = new ComputadorBll();

        [HttpGet("all")]
        public IActionResult GetALL()
        {
            return Json(PcBLL.getAll());
        }
    }
}