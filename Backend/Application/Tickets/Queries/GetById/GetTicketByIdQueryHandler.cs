using Domain.Tickets;
using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Queries.GetById
{
    public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery,Ticket?>
    {
        private readonly ITicketsRepository _ticketsRepository;
        public GetTicketByIdQueryHandler(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }
        public async Task<Ticket?> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ticketsRepository.GetTicketById(request.ticketId);
        }
    }
}
