using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Application.Common;
using MediatR;
using EventSchedulingAndRegistration.Application.Common.CQRS;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllUsersByEventId
{
    public record GetUsersByEventIdResult(DefaultGenericResponseDTO<List<UserDto>> Users);

    public record GetAllUsersByEventIdQuery(Guid EventId) : IQuery<GetUsersByEventIdResult>
    {
    }
}
