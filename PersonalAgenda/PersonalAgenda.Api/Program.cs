using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalAgenda.Business;
using PersonalAgenda.Business.Queries;
using PersonalAgenda.Domain.Entities;
using PersonalAgenda.EFDataAccess;
using PersonalAgenda.EFDataAccess.Repositories;
using PersonalAgenda.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetMeetingsQuery).GetTypeInfo().Assembly));

builder.Services.AddDbContext<PersonalAgendaContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        ));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
