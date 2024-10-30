using EventSchedulingAndRegistration.Application.Abstract.Repositories;
using EventSchedulingAndRegistration.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Application.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<User> User { get; }
        IGenericRepository<Event> Event { get; }
        IGenericRepository<EventRegistration> EventRegistration { get; }
        Task<int> SaveChangesAsync();


    }
}
