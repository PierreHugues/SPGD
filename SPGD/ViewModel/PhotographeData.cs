using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.ViewModel
{
    public class PhotographeData
    {
        public IEnumerable<Photographe> Photographes { get; set; }
        public IEnumerable<Seance> Seances { get; set; }
    }
}