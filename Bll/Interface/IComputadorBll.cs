using System.Collections.Generic;
using Dal.Dominio;
using Dal.Model;

namespace Bll.Interface 
{
    public interface IComputadorBll
    {
        List<Computador> getAll();
    }
}