using System.Reflection;
using ContactManager.Application.Extensions;
using ContactManager.Database.Postgre;
using ContactManager.Database.Postgre.Repositories;
using ContactManager.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediator();

builder.Services.AddScoped<IContactManagerRepository, ContactManagerRepository>();

builder.Services.AddDbContext<ContactManagerDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();