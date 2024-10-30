using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common;
using MediatR;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.RegisterEvents
{
    public record RegisterEventCommand(Guid EventId) : ICommand<DefaultGenericResponseDTO<Unit>>
    {
    }
}
