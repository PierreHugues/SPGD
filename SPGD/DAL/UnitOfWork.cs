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
        private RendezVousRepository rendezVousRepository;
        private AgentRepository agentRepository;
        private PhotoRepository photoRepository;


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

        public RendezVousRepository RendezVousRepository
        {
            get
            {
                if (this.rendezVousRepository == null)
                {
                    this.rendezVousRepository = new RendezVousRepository(context);
                }
                return rendezVousRepository;
            }
        }

        public AgentRepository AgentRepository
        {
            get
            {
                if (this.agentRepository == null)
                {
                    this.agentRepository = new AgentRepository(context);
                }
                return agentRepository;
            }
        }

        public PhotoRepository PhotoRepository
        {
            get
            {
                if (this.photoRepository == null)
                {
                    this.photoRepository = new PhotoRepository(context);
                }
                return photoRepository;
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