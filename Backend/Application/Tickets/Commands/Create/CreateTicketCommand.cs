using Domain.Tickets;
using Infrastructure.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tickets.Commands.Create
{
    public record CreateTicketCommand(TicketForCreate TicketForCreate) : IRequest;
}
