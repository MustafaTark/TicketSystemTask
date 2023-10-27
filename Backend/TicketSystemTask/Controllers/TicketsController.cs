using Application.Tickets.Commands.Create;
using Application.Tickets.Commands.Update;
using Application.Tickets.Commands.UpdateHandle;
using Application.Tickets.Queries.GetAll;
using Application.Tickets.Queries.GetById;
using Domain.Tickets;
using Infrastructure.DTO;
using Infrastructure.RequestFeature;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator; 
        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TicketsParamters paramters)
        {
            return Ok(
                await _mediator.Send(new GetAllTicketsQuery(paramters))
                );
        }
        [HttpPost]
        public async Task<IActionResult> Create(TicketForCreate ticketForCreate)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(new CreateTicketCommand(ticketForCreate));
            return StatusCode(201);
        }
        [HttpPut("Handle/{ticketId}")]
        public async Task<IActionResult> Handel(int ticketId)
        {
            Ticket ticket = await _mediator.Send(new GetTicketByIdQuery(ticketId));
            if(ticket  is null)
            {
                return NotFound("this ticketId not founded in database");
            }
            await _mediator.Send(new UpdateTicketHandleCommand(ticketId));
            return NoContent();
        }
        [HttpDelete("{ticketId}")]
        public async Task<IActionResult> Delete(int ticketId)
        {
            Ticket ticket = await _mediator.Send(new GetTicketByIdQuery(ticketId));
            if (ticket is null)
            {
                return NotFound("this ticketId not founded in database");
            }
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]Ticket ticket)
        {
            Ticket ticketEntity = await _mediator.Send(new GetTicketByIdQuery(ticket.Id));
            if (ticket is null)
            {
                return NotFound("this ticketId not founded in database");
            }
            await _mediator.Send(new UpdateTicketCommand(ticket));
            return Ok(ticketEntity);
        }
    }
}
