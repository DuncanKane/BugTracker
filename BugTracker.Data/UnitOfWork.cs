using BugTracker.Data.Context;
using BugTracker.Data.Interfaces;
using BugTracker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data
{
    public class UnitOfWork : BugTrackerContext, IUnitOfWork
    {
        private readonly IBugTrackerContext _context;
                                        
        public UnitOfWork(IBugTrackerContext context)
        {
            _context = context;

            Bugs = new BugRepository(_context);
            Tickets = new TicketRepository(_context);            
        }

        public IBugRepository Bugs { get; private set; }

        public  ITicketRepository Tickets { get; private set; }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
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



        int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
