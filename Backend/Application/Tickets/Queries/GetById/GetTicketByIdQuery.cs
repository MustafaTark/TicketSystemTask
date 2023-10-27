using Domain.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Queries.GetById
{
    public record GetTicketByIdQuery(int ticketId) : IRequest<Ticket>;
}
