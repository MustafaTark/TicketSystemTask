using Domain.Tickets;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Commands.Update
{
    public record UpdateTicketCommand(Ticket Ticket) : IRequest;
}
