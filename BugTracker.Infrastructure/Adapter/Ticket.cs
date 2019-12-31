using BugTracker.Data.Interfaces;
using BugTracker.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Infrastructure
{
    public class Ticket : ITicket
    {
        private readonly IUnitOfWork _unitOfWork;
            
        public Ticket(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Core.Entities.Ticket Get(Guid id)
        {
            var dataTicket = _unitOfWork.Tickets.Get(id);

            return ConvertDataEntityToSystemEntity(dataTicket);
        }

        private Core.Entities.Ticket ConvertDataEntityToSystemEntity(BugTracker.Data.Entities.Ticket dataTicket)
        {
            return dataTicket != null
                ? Mapping.Mapper.Map<Core.Entities.Ticket>(dataTicket)
                : null;
        }
    }
}
