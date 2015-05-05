using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPGD.DAL
{
    interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}