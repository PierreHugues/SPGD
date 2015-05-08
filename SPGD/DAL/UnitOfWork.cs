using SPGD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private H15_PROJET_E09Entities1 context = new H15_PROJET_E09Entities1();

        private SeanceRepository seanceRepository;

        public SeanceRepository SeanceRepository
        {
            get
            {
                if (this.seanceRepository == null)
                {
                    this.seanceRepository = new SeanceRepository(context);
                }
                return seanceRepository;
            }
        }




        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}