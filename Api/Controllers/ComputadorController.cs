using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll.Interface;
using Bll.Implementation;
using Dal.Dominio;
using Dal.Model;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ComputadorController : Controller
    {
        IComputadorBll PcBLL = new ComputadorBll();

        [HttpGet("all")]
        public IActionResult GetALL()
        {
            List<CompitadorSemDescricaoDTO> pcs = PcBLL.getAll();
            return Json(pcs);
        }

        [HttpGet("{id}")]
        public IActionResult GetFind(int id)
        {
            Computador pc = PcBLL.GetFind(id);
            return Json(pc);
        }

        [HttpPost]
        public IActionResult PostComp([FromBody]Computador computador)
        {
            Computador pc = PcBLL.Insert(computador);
            return Json(pc);
        }

        [HttpPut]
        public IActionResult PutComp([FromBody]Computador computador)
        {
            
            Computador pc = PcBLL.Update(computador);
            return Json(pc);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComp(int id)
        {
            Computador pc = PcBLL.Delete(id);
            return Json(pc);
        }

        [HttpGet("avista/{id}")]
        public IActionResult GetCompPrecoAVista(int id)
        {
            Computador pc = PcBLL.GetCompPrecoAVista(id);
            return Json(pc);
        }

        [HttpGet("apraso/{id}/{parcelas}")]
        public IActionResult GetCompPrecoAPraso(int id, int parcelas)
        {
            Computador pc = PcBLL.GetCompPrecoParcelado(id, parcelas);
            return Json(pc);
        }
    }
}