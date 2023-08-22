using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TasteTrove.API.DTOs;
using TasteTrove.Application;
using TasteTrove.Application.Users.Commands;
using TasteTrove.Application.Users.Queries;
using TasteTrove.Domain;
using TasteTrove.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperMarker));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<MeditorMarker>();
});

builder.Services.AddDbContext<TasteTroveContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapPost("/api/create/user", async (CreateUserDTO userDTO, IMediator mediator, IMapper mapper) =>
{
    var mappingResult = mapper.Map<User>(userDTO);
    var result = await mediator.Send(new CreateUserCommand(mappingResult));
    return Results.Ok(result);
}).WithName("PostUser");

app.MapGet("/api/all-users", async (IMediator mediator) =>
{
    var result = await mediator.Send(new GetAllUsersQuery());
    return Results.Ok(result);
}).WithName("GetUsers");

app.MapDelete("/api/all-users", async ([Required] Guid id, IMediator mediator) =>
{
    var result = await mediator.Send(new DeleteUserCommand { Id = id });
    if (result == true)
    {
        return Results.NoContent();
    }
    return Results.NotFound();
}).WithName("DeleteUsers");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}