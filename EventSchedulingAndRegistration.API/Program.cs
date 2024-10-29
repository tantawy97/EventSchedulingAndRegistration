
using EventSchedulingAndRegistration.API;
using EventSchedulingAndRegistration.Application;
using EventSchedulingAndRegistration.Application.Common.Logger;
using EventSchedulingAndRegistration.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddProblemDetails();
Log.Logger = LoggerConfigurations.CreateSerilogLogger("test");
builder.Host.UseSerilog();
// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.

var app = builder.Build();
app.UseApiServices();

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

