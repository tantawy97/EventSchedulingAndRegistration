using EventSchedulingAndRegistration.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace EventSchedulingAndRegistration.Application.Data;
public interface IApplicationDbContext
{
    DbSet<Event> Events { get; }
    DbSet<User> Users { get; }
    DbSet<EventRegistration> EventRegistrations { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
