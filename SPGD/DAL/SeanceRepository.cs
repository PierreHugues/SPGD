using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    public class SeanceRepository : GenericRepository<Seance>
    {
        public SeanceRepository(H15_PROJET_E09Entities1 context) : base(context) { }

        public IEnumerable<Seance> GetSeances()
        {
            IEnumerable<Seance> seances;
            seances = Get();
            seances = seances.OrderBy(s => s.DateDebutDeSeance);

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