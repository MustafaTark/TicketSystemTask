using Application.Tickets.Commands.Create;
using Application.Tickets.Commands.Delete;
using Application.Tickets.Commands.Update;
using Application.Tickets.Commands.UpdateHandle;
using Application.Tickets.Queries.GetAll;
using Application.Tickets.Queries.GetById;
using Domain.Tickets;
using Infrastructure;
using Infrastructure.Contracts;
using Infrastructure.DTO;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(opts =>
                                    opts.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")
                                    , b => b.MigrationsAssembly("WEB API")));
var MyAllowSpecificOrigins = "_TicketSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
               policy =>
               {
                   policy.SetIsOriginAllowed(origin => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
               });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<ITicketsRepository,TicketsRepository>();
builder.Services.AddScoped<IRequestHandler<GetAllTicketsQuery, IEnumerable<TicketForView>> ,GetAllTicketsQueryHandler>();
builder.Services.AddScoped<IRequestHandler<CreateTicketCommand>, CreateTicketCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateTicketHandleCommand>, UpdateTicketHandleCommandHandaler>();
builder.Services.AddScoped<IRequestHandler<UpdateTicketCommand>, UpdateTicketCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateTicketCommand>, UpdateTicketCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteTicketCommand>, DeleteTicketCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetTicketByIdQuery,Ticket?>, GetTicketByIdQueryHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
