using BugTracker.Data.Entities;
using BugTracker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {

    }
}
