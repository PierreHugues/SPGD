using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPGD.DAL
{
    public class SeanceRepository : GenericRepository<Seance>
    {
        public SeanceRepository(H15_PROJET_E09Entities1 context) : base(context) { }

        public IEnumerable<Seance> GetSeancesRDV()
        {
            IEnumerable<Seance> seances;
            seances = Get().Where(s=>s.RendezVou != null);
            seances = seances.OrderByDescending(s => s.DateDebutDeSeance).OrderBy(s => s.RendezVou.DateHeureRendezVous);
          //  var seances = (from s in seances
           //                    join r in rendezvous on s.SeanceID equals r.)
            return seances;
        }

        public IEnumerable<Seance> GetSeancesSansRDV()
        {
            IEnumerable<Seance> seances;
            seances = Get().Where(s => s.RendezVou == null);
            seances = seances.OrderByDescending(s => s.DateDebutDeSeance);
            return seances;
        }

        public Seance GetSeanceByID(int? id)
        {
            return GetByID(id);
        }

        public void InsertSeance(Seance seance)
        {
            Insert(seance);
        }

        public void UpdateSeance(Seance seance)
        {
            Update(seance);
        }

        public void DeleteSeance(int id)
        {
            Delete(id);

        }
    }
}