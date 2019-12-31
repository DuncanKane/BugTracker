using BugTracker.Data.Interfaces;

namespace BugTracker.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IBugRepository Bugs { get; }
        ITicketRepository Tickets { get; }
        void Dispose();
    }
}