using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Extensions.Hosting;

namespace EventSchedulingAndRegistration.Application.Common.Logger
{
    public static class LoggerConfigurations
    {
        public static ReloadableLogger CreateSerilogLogger(string applicationName)
        {
            string environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? throw new ArgumentNullException("ASPNETCORE_ENVIRONMENT is not set");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            LoggerConfiguration loggerConfiguration = new();
            loggerConfiguration = loggerConfiguration.ReadFrom.Configuration(configuration);
            loggerConfiguration.Enrich.WithProperty("environment", environmentName ?? "EnvironmentName not set, check the application settings");
            loggerConfiguration.Enrich.WithProperty("application", applicationName ?? "ApplicationName not set, check the application settings");

            return loggerConfiguration.CreateBootstrapLogger();
        }
    }
}
