using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.ViewModel
{
    public class SeanceData
    {
        public IEnumerable<Seance> seancesSansRDV { get; set; }

        public IEnumerable<Seance> seancesAvecRDV { get; set; }
    }
}