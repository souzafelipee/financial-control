using FinancialControl.Application.Consumers;
using FinancialControl.Application.Interfaces.UseCases;
using FinancialControl.Application.UseCases.Transaction;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Infra.CrossCutting.IoC;
using FinancialControl.Infra.CrossCutting.Mappers;
using FinancialControl.Infra.EntityFramework;
using FinancialControl.Infra.EntityFramework.Repository;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(TransactionProfile));


builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=127.0.0.1;Database=financial-control;Uid=sa;Pwd=Senha@2023;");
});

builder.Services.AddDependencyInjection();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(RegisterTransactionConsumer));
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
