using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common.DTOs;
using MediatR;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllEventByUserId
{
    public record GetEventsByUserIdResult(DefaultGenericResponseDTO<List<EventDto>> Events);

    public record GetAllEventByUserIdQuery(Guid UserId) : IQuery<GetEventsByUserIdResult>;
}
