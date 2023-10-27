using Infrastructure.Contracts;
using Infrastructure.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Queries.GetAll
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery,IEnumerable<TicketForView>>
    {
        private readonly ITicketsRepository _ticketsRepository;
        public GetAllTicketsQueryHandler(ITicketsRepository ticketsRepository)
        {
            _ticketsRepository = ticketsRepository;
        }
        public Task<IEnumerable<TicketForView>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            return _ticketsRepository.GetAllTickets(request.Paramters);
        }
    }
}
