using BugTracker.Data.Entities;
using BugTracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.Context
{
    public class BugTrackerContext : DbContext, IBugTrackerContext
    {
        public BugTrackerContext() : base("name=BugTrackerConn")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BugTrackerContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LogToTicket> LogsToTickets { get; set; }

        public static BugTrackerContext Create()
        {
            return new BugTrackerContext();
        }
    }
}
