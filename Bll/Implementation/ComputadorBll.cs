using System;
using Bll.Interface;
using Dal.Dominio;
using Dal.Model;
using Dal.DAO;
using System.Collections.Generic;
using System.Text;

namespace Bll.Implementation
{
    public class ComputadorBll : IComputadorBll
    {

        private static ComputadorDAO pcDAO;

        public ComputadorBll()
        {
            pcDAO = ComputadorDAO.SingletonDAO();
        }

        public ComputadorBll(ComputadorDAO pcDAO2)
        {
            pcDAO = pcDAO2; 
        }

        public List<CompitadorSemDescricaoDTO> getAll()
        {
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
            return pcDAO.GetFind(id);
        }

        public Computador Insert(Computador computador)
        {
            return pcDAO.Insert(computador);
        }

        public Computador Update(Computador computador)
        {
            return pcDAO.Update(computador);
        }

        public Computador Delete(int id)
        {
            return pcDAO.Delete(id);
        }

        public Computador GetCompPrecoAVista(int id)
        {
            Computador compDesconto = pcDAO.GetFind(id);
            compDesconto.preco = ((compDesconto.preco * 90)/100);
            return compDesconto;
        }

        public Computador GetCompPrecoParcelado(int id, int qtdParcelas)
        {
            Computador compParcelado = pcDAO.GetFind(id);
            compParcelado.preco = (compParcelado.preco/qtdParcelas);
            
            for (int i = 0; i < qtdParcelas; i++)
            {
                compParcelado.preco = ((compParcelado.preco * 102)/100);
            }
            return compParcelado;
        }
    }
}