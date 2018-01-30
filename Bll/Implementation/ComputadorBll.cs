using System;
using Bll.Interface;
using Bll.Network;
using Dal.Dominio;
using Dal.Model;
using Dal.DAO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Bll.Implementation
{
    public class ComputadorBll : IComputadorBll
    {
        public List<CompitadorSemDescricaoDTO> getAll()
        {
            ComputadorDAO pcDAO = new ComputadorDAO();
            List<CompitadorSemDescricaoDTO> pcs = new List<CompitadorSemDescricaoDTO>();

            List<Computador> Computadores = pcDAO.GelAll();

            foreach (Computador item in Computadores)
            {
                var computador = new CompitadorSemDescricaoDTO()
                {
                    Nome = item.Nome,
                    preco = item.preco
                };
                pcs.Add(computador);
            }
            return pcs;
        }

        public Computador GetFind(int id)
        {
            ComputadorDAO pcDAO = new ComputadorDAO();
            return pcDAO.GetFind(id);
        }

        public Computador Insert(Computador computador)
        {
            ComputadorDAO pcDAO = new ComputadorDAO();
            return pcDAO.Insert(computador);
        }

        public Computador Update(Computador computador)
        {
            ComputadorDAO pcDAO = new ComputadorDAO();
            return pcDAO.Update(computador);
        }

        public Computador Delete(int id)
        {
            ComputadorDAO pcDAO = new ComputadorDAO();
            return pcDAO.Delete(id);
        }

        public Computador GetCompPrecoAVista(int id)
        {
            ComputadorDAO pcDAO = new ComputadorDAO();
            Computador compDesconto = pcDAO.GetFind(id);
            return compDesconto;
        }

        public Computador GetCompPrecoParcelado(int id, int qtdParcelas)
        {
            ComputadorDAO pcDAO = new ComputadorDAO();
            Computador compParcelado = pcDAO.GetFind(id);
            for (int i = 0; i <= qtdParcelas; i++)
            {
                compParcelado.preco = (compParcelado.preco * 102)/100;
            }
            compParcelado.preco = (compParcelado.preco/qtdParcelas);
            return compParcelado;
        }
    }
}