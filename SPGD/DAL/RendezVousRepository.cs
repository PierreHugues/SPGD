using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    public class RendezVousRepository : GenericRepository<RendezVou>
    {
        public RendezVousRepository(H15_PROJET_E09Entities1 context) : base(context) { }

        public IEnumerable<RendezVou> GetRendezVous()
        {
            return Get();
        }

        public RendezVou GetRendezVousByID(int? id)
        {
            return GetByID(id);
        }

        public void InsertRendezVous(RendezVou rendezVou)
        {
            Insert(rendezVou);
        }

        public void UpdateRendezVou(RendezVou rendezVou)
        {
            Update(rendezVou);
        }

        public void DeleteRendezVou(int id)
        {
            Delete(id);
        }
    }
}