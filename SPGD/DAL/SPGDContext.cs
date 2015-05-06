using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SPGD.DAL
{
    public class SPGDContext : DbContext
    {
        public DbSet<Seance> Sceances { get; set; }
    }
}
