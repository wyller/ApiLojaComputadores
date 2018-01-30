using System.Collections.Generic;
using Dal.Dominio;
using Dal.Model;

namespace Bll.Interface 
{
    public interface IComputadorBll
    {
        List<CompitadorSemDescricaoDTO> getAll();

        Computador GetFind(int id);
        Computador GetCompPrecoAVista(int id);

        Computador GetCompPrecoParcelado(int id, int qtdParcelas);

        Computador Insert(Computador computador);
        Computador Update(Computador computador);
        Computador Delete(int id);
    }
}