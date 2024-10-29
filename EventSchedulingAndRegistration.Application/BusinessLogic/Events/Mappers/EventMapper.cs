using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Mappers
{
    public static class EventMapper
    {
        public static EventDto ToDto(this Event eventEntity)
        {
            return new EventDto(
                eventEntity.Id,
                eventEntity.Title,
                eventEntity.Description,
                new LocationDto(eventEntity.Location.City, eventEntity.Location.StreetName),
                eventEntity.Date
            );
        }

        // List mapping
        public static List<EventDto> ToDtoList(this IEnumerable<Event> events)
        {
            return events.Select(e => e.ToDto()).ToList();
        }
    }
}
