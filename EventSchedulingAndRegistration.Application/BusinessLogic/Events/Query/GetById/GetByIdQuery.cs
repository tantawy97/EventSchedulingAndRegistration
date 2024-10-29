using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common.DTOs;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Query.GetById
{
    public record GetEventByIdResult(DefaultGenericResponseDTO<EventDto> @event);

    public record GetByIdQuery(Guid Id) : IQuery<GetEventByIdResult>
    {
    }
}
