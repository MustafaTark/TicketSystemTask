using Domain.Tickets;
using Infrastructure.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Commands.Create
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand>
    {
        private readonly ITicketsRepository _ticketsRepository;
        public CreateTicketCommandHandler(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }
        public async Task Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            await _ticketsRepository.Create(request.TicketForCreate);
        }
    }
}
