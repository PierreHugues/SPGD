using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private SPGDContext context = new SPGDContext();

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