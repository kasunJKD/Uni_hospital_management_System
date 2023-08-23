using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uni_hospital.Repositories.Interfaces;

namespace Uni_hospital.Repositories.Implementations
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        private bool disposed = false;
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposed);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> repository = new GenericRepository<T>(_context);
            return repository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
