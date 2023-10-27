using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Commands.Update
{
    public class UpdateTicketCommandHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly ITicketsRepository _ticketsRepository;
        public UpdateTicketCommandHandler(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }

        public async Task Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            await _ticketsRepository.Update(request.Ticket);
        }
    }
}
