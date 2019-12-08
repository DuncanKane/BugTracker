using System.Data.Entity;
using BugTracker.Data.Entities;

namespace BugTracker.Data.Interfaces
{
    public interface IBugTrackerContext : IDbContext
    {
        DbSet<Bug> Bugs { get; set; }
        DbSet<Log> Logs { get; set; }
        DbSet<LogToTicket> LogsToTickets { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<User> Users { get; set; }
    }
}