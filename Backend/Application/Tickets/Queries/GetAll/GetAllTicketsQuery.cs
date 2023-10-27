using Infrastructure.DTO;
using Infrastructure.RequestFeature;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Queries.GetAll
{
    public record GetAllTicketsQuery(TicketsParamters Paramters) : IRequest<IEnumerable<TicketForView>>;
}
