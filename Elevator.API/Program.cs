using Elevator.API.Application.Interfaces;
using Elevator.API.Application.Services;
using Elevator.API.Infraestructure.Queues;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IElevatorMovement, ElevatorService>();
builder.Services.AddSingleton<IElevatorDoorControl, ElevatorService>();
builder.Services.AddSingleton<IRequestQueue, RequestQueue>();
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
