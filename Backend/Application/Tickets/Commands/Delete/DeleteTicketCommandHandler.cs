using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Commands.Delete
{
    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand>
    {
        private readonly ITicketsRepository _ticketsRepository;
        public DeleteTicketCommandHandler(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }
        public async Task Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            await _ticketsRepository.Delete(ticketId: request.TicketId);
        }
    }
}
