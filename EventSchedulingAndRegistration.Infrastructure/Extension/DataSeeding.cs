using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Domain.ValueObject;
using EventSchedulingAndRegistration.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Infrastructure.Extension
{
    public static class DataSeeding
    {
        public static async Task InitializeDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.MigrateAsync().GetAwaiter().GetResult();
            if (!await context.Users.AnyAsync(w => w.Email == "Admin@Admin.com"))
            {
                await context.Users.AddRangeAsync(User);
                await context.SaveChangesAsync();
            }
        }
        public static User User =>
        User.Create("Admin", "Admin@Admin.com", "1234", PersonalInformation.Of("1st Street", "01013232294"));
    }
}

