using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using MediatR;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.Cancels
{
    public record CancelCommand(Guid EventId) : ICommand<DefaultGenericResponseDTO<Unit>>
    {
    }
}
