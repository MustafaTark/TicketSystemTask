using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Commands.Delete
{
    public record DeleteTicketCommand(int TicketId) : IRequest
    {
    }
}
