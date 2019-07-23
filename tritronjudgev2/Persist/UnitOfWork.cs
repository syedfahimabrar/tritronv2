using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tritronAPI.Data;

namespace tritronAPI.Persist
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
            this.ProblemRepository = new ProblemRepository(context);
            this.ProblemRepository = new ProblemRepository(context);
        }
        public IProblemRepository ProblemRepository { get; set; }
        public ITestRepository TestRepository { get; set; }
        
        private bool disposed = false;

        public void Save()
        {
            _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
