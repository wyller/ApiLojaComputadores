using Dal.Model;
using Dal.Context;
using System.Collections.Generic;
using System.Linq;
using Dal.Dominio;

namespace Dal.DAO
{
    public class ComputadorDAO
    {
        private static ComputadorDAO instance;

        public static ComputadorDAO SingletonDAO()
        {
            if(instance == null)
            {
                instance = new ComputadorDAO();
            }
            return instance;
        }

        public List<Computador> GelAll()
        {
            using(Contexto db = new Contexto())
            {
                List<Computador> computador = new List<Computador>();
                computador = db.Computador.ToList();
                return computador;
            }
        }

        public Computador GetFind(int id)
        {
            using(Contexto db = new Contexto())
            {
                Computador computador = new Computador();
                computador = db.Computador.Find(id);
                return computador;
            }
        }

        public Computador Insert(Computador newComp)
        {
            using(Contexto db = new Contexto())
            {
                db.Computador.Add(newComp);
                db.SaveChanges();
                return newComp;
            }
        }

        public Computador Update(Computador newComp)
        {
            using(Contexto db = new Contexto())
            {
                db.Computador.Update(newComp);
                db.SaveChanges();
                return newComp;
            }
        }
        
        public Computador Delete(int id)
        {
            using(Contexto db = new Contexto())
            {
                var comp = db.Computador.Find(id);
                db.Computador.Remove(comp);
                db.SaveChanges();
                return comp;
            }
        }
    }
}