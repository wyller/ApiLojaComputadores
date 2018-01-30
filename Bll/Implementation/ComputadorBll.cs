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
        public List<Computador> getAll()
        {
            ComputadorDAO pcDAO = new ComputadorDAO();
            return pcDAO.GelAll();
        }
    }
}
