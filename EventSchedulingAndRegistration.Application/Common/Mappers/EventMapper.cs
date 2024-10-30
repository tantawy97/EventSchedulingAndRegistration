using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Application.Common.Mappers
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
        public static UserDto ToDto(this User userEntity)
        {
            return new UserDto(
                userEntity.Id,
                userEntity.Email,
                userEntity.Name,
               new PersonalInformationDto(userEntity.PersonalInformation.PhoneNumber, userEntity.PersonalInformation.Address)
            );
        }
        public static List<EventDto> ToDtoList(this IEnumerable<Event> events)
        {
            return events.Select(e => e.ToDto()).ToList();
        } 
        public static List<UserDto> ToDtoList(this IEnumerable<User> users)
        {
            return users.Select(e => e.ToDto()).ToList();
        }
    }
}
