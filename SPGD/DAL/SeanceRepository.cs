using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    public class SeanceRepository : GenericRepository<Seance>
    {
        public SeanceRepository(SPGDContext context) : base(context) { }

        public IEnumerable<Seance> GetSeances()
        {
            return Get();
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