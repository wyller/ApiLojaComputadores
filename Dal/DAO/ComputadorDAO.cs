using Dal.Model;
using Dal.Context;
using System.Collections.Generic;
using System.Linq;

namespace Dal.DAO
{
    public class ComputadorDAO
    {
        public List<Computador> GelAll()
        {
            using(Contexto db = new Contexto())
            {
                List<Computador> computador = new List<Computador>();
                computador = db.Computador.ToList();
                return computador;
            }
        }
    }
}