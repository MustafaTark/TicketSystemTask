using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Commands.UpdateHandle
{
    public class UpdateTicketHandleCommandHandaler : IRequestHandler<UpdateTicketHandleCommand>
    {
        private ITicketsRepository _ticketsRepository;
        public UpdateTicketHandleCommandHandaler(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }
        public async Task Handle(UpdateTicketHandleCommand request, CancellationToken cancellationToken)
        {
            await _ticketsRepository.Handle(request.TicketId);
        }
    }
}
