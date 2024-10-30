using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Abstract.Services;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Domain.Model;
using MediatR;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.RegisterEvents
{
    public class RegisterEventCommandHandler(IUnitOfWork _unitOfWork, ITokenService _tokenService) : IRequestHandler<RegisterEventCommand, DefaultGenericResponseDTO<Unit>>
    {
        public async Task<DefaultGenericResponseDTO<Unit>> Handle(RegisterEventCommand request, CancellationToken cancellationToken)
        {
            var registration = EventRegistration.Create(_tokenService.UserId, request.EventId);
            await _unitOfWork.EventRegistration.CreateAsync(registration);
            await _unitOfWork.SaveChangesAsync();
            return DefaultGenericResponseDTO<Unit>.SuccessResponse(Unit.Value);
        }
    }
}
