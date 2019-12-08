using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.Entities
{
    public class LogToTicket
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Ticket")]
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        [ForeignKey("Log")]
        public Guid LogId { get; set; }
        public Log Log { get; set; }
    }
}
