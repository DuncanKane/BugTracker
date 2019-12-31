using BugTracker.Data.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Ticket
    {        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketPriority TicketPriority { get; set; }
    }
}
