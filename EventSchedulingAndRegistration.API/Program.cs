
using EventSchedulingAndRegistration.API;
using EventSchedulingAndRegistration.Application;
using EventSchedulingAndRegistration.Application.Common.Logger;
using EventSchedulingAndRegistration.Infrastructure;
using EventSchedulingAndRegistration.Infrastructure.Extension;
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

// Add Pipeline
var app = builder.Build();
app.UseApiServices();
await app.InitializeDatabaseAsync();

app.Run();
