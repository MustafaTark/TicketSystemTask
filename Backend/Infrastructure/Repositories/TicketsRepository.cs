using Domain.Tickets;
using Infrastructure.Contracts;
using Infrastructure.DTO;
using Infrastructure.RequestFeature;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TicketsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IEnumerable<TicketForView>> GetAllTickets(TicketsParamters paramters)
           => await _applicationDbContext.Tickets
                                         .AsNoTracking()
                                         .Select(t=> new TicketForView
                                         {
                                           Id = t.Id,
                                           CityId = t.CityId,
                                           CreatedDate = t.CreatedDate,
                                           NumberOfMinutes = (int) (DateTime.Now - t.CreatedDate).TotalMinutes,
                                           DistrictId = t.DistrictId,
                                           GovernateId = t.GovernateId,
                                           IsHandled = t.IsHandled,
                                           PhoneNumber = t.PhoneNumber,
                                         })
                                         .Skip((paramters.PageNumber - 1) * paramters.PageSize)
                                         .Take(paramters.PageSize)
                                         .ToListAsync();
        public async Task<Ticket?> GetTicketById (int id)
           => await _applicationDbContext.Tickets.FirstOrDefaultAsync(c=>c.Id== id);

        public async Task Create(TicketForCreate ticketForCreate)
        {
            Ticket ticket = new Ticket
            {
                PhoneNumber = ticketForCreate.PhoneNumber,
                CityId = ticketForCreate.CityId,
                DistrictId = ticketForCreate.DistrictId,
                GovernateId = ticketForCreate.GovernateId,
                CreatedDate = DateTime.Now,
                IsHandled = false
            };
            await _applicationDbContext.Tickets.AddAsync(ticket);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task Handle(int ticketId)
        {
            

              var result=  await _applicationDbContext.Database.ExecuteSqlRawAsync($"Update Tickets SET IsHandled = 1 Where Id = {ticketId}  ");
            
          
         }

        public async Task Delete(int ticketId)
        {
            await _applicationDbContext.Database.ExecuteSqlRawAsync($"Delete From Tickets where Id = {ticketId}");
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task Update(Ticket ticket)
        {
            var ticketEntity = await _applicationDbContext.Tickets.FirstOrDefaultAsync(t=>t.Id== ticket.Id);
            ticketEntity.PhoneNumber = ticket.PhoneNumber;
            ticketEntity.CityId = ticket.CityId;
            ticketEntity.DistrictId = ticket.DistrictId;
            ticketEntity.GovernateId = ticket.GovernateId;
            ticketEntity.CreatedDate = ticket.CreatedDate;
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
