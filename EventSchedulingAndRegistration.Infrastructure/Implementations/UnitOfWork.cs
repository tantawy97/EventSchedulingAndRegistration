using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Abstract.Repositories;
using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Infrastructure.Data;
using EventSchedulingAndRegistration.Infrastructure.Implementations.Repositories;
using Microsoft.Extensions.Logging;

namespace EventSchedulingAndRegistration.Infrastructure.Implementations
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Event> Event { get; private set; }
        public IGenericRepository<User> User { get; private set; }
        public IGenericRepository<EventRegistration> EventRegistration { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Event = new GenericRepository<Event>(_context);
            User = new GenericRepository<User>(_context);
            EventRegistration = new GenericRepository<EventRegistration>(_context);

        }

        public void Dispose() => _context.Dispose();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
