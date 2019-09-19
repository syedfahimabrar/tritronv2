using System;
using Contracts;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _context;

        public UnitOfWork(DataContext context)
        {
            this._context = context;
            this.ProblemRepository = new ProblemRepository(context);
            this.ProblemRepository = new ProblemRepository(context);
            this.ContestRepository = new ContestRepository(context);
            this.LanguageRepository = new LanguageRepository(context);
        }
        public IProblemRepository ProblemRepository { get; set; }
        public ITestRepository TestRepository { get; set; }
        public IContestRepository ContestRepository { get; set; }
        public ILanguageRepository LanguageRepository { get; set; }
        
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
