using Domain.Tickets;
using Infrastructure.DTO;
using Infrastructure.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface ITicketsRepository
    {
        Task<IEnumerable<TicketForView>> GetAllTickets(TicketsParamters paramters);
        Task<Ticket?> GetTicketById(int id);
        Task Create(TicketForCreate ticketForCreate);
        Task Handle(int ticketId);
        Task Delete(int ticketId);
        Task Update(Ticket ticket);
    }
}
