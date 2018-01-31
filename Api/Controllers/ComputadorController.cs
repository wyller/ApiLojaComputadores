using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bll.Interface;
using Bll.Implementation;
using Dal.Model;
using Dal.Dominio;
using Swashbuckle.AspNetCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ComputadorController : Controller
    {
        IComputadorBll PcBLL = new ComputadorBll();

        /// <summary>
        /// Buscar todos os computadores no banco
        /// </summary>
        /// <returns>Uma lista de computadores</returns>
        [HttpGet("all")]
        public IActionResult GetALL()
        {
            List<CompitadorSemDescricaoDTO> pcs = PcBLL.getAll();
            return Json(pcs);
        }

        /// <summary>
        /// Busca especifica por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um computador</returns>
        [HttpGet("{id}")]
        public IActionResult GetFind(int id)
        {
            Computador pc = PcBLL.GetFind(id);
            return Json(pc);
        }

        /// <summary>
        /// Adicionar um computador
        /// </summary>
        /// <param name="computador"></param>
        /// 
        /// <returns>O Computador já adicionado</returns>
        [HttpPost]
        public IActionResult PostComp([FromBody]Computador computador)
        {
            Computador pc = PcBLL.Insert(computador);
            return Json(pc);
        }

        /// <summary>
        /// Alterar um computador
        /// </summary>
        /// <param name="computador"></param>
        /// <returns>O Computador já alterado</returns>
        [HttpPut]
        public IActionResult PutComp([FromBody]Computador computador)
        {
            
            Computador pc = PcBLL.Update(computador);
            return Json(pc);
        }

        /// <summary>
        /// Deletar um computador pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O computador removido</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteComp(int id)
        {
            Computador pc = PcBLL.Delete(id);
            return Json(pc);
        }

        /// <summary>
        /// Buscar o computador com o preço a vista com desconto de 10%
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O computador com o valor já com o desconto</returns>
        [HttpPost("avista/{id}")]
        public IActionResult GetCompPrecoAVista(int id)
        {
            Computador pc = PcBLL.GetCompPrecoAVista(id);
            return Json(pc);
        }

        /// <summary>
        /// Buscar o computador com o preço parcelado com acrescimo de 2% por mes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parcelas"></param>
        /// <returns>O computador com o valor já com o acrescimo</returns>
        [HttpPost("apraso/{id}/{parcelas}")]
        public IActionResult GetCompPrecoAPraso(int id, int parcelas)
        {
            Computador pc = PcBLL.GetCompPrecoParcelado(id, parcelas);
            return Json(pc);
        }
    }
}