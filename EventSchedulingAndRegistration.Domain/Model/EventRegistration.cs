using EventSchedulingAndRegistration.Domain.Abstract;
using EventSchedulingAndRegistration.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Domain.Model
{
    public class EventRegistration : Entity
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public User User { get; set; } = default!;
        public Event Event { get; set; } = default!;
        public EventRegistration Create(Guid userId, Guid eventId)
        {
            var eventRegistration = new EventRegistration
            {
                UserId = userId,
                EventId = eventId,
            };
            return eventRegistration;
        }  
    }
}
