using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    public class PhotographeRepository: GenericRepository<Photographe>
    {
        public PhotographeRepository(H15_PROJET_E09Entities1 context) : base(context) { }

        public IEnumerable<Photographe> GetPhotographes()
        {
            return Get();
        }
        public Photographe GetPhotographeByID(int? id)
        {
            return GetByID(id);
        }
        public void InsertPhotographe(Photographe photographe)
        {
            Insert(photographe);
        }
        public void UpdatePhotographe(Photographe photographe)
        {
            Update(photographe);
        }
        public void DeletePhotographe(int id)
        {
            Delete(id);
        }


        public IEnumerable<Seance> GetSeancesSelonPhotographe(int id)
        {
            //Seance seances = Get(filter: ph => ph.PhotographeID == id, includeProperties: "Seances").ToList().Single();
            Photographe photographe = GetByID(id);
            return photographe.Seances;
        }


        //public IEnumerable<Seance> GetSeancesDerniereAnnéeSelonAgent(int id)
        //{
        //    IEnumerable<Seance> seances;
        //    seances = Get(filter: ph => ph.PhotographeID == id, includeProperties: "Seances").ToList().Single();
        //    //seances = Get().Where(s => s.AgentID == agent.AgentID && s.DateDebutDeSeance.Year == DateTime.Now.Year);
        //    seances = seances.OrderByDescending(s => s.DateDebutDeSeance);
        //    return seances;
        //}
        //public IEnumerable<Seance> GetSeancesSelonPhotographe(int id)
        //{
        //    IEnumerable<Seance> seances;
        //    seances = Get().Where(s => s.PhotographeID == id);
        //    seances = seances.OrderByDescending(s => s.DateDebutDeSeance);
        //    return seances;
        //}
    }
}