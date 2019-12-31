using BugTracker.Core.Entities;
using System;

namespace BugTracker.Infrastructure.Specifications
{
    public interface ITicket
    {
        Core.Entities.Ticket Get(Guid id);
    }
}