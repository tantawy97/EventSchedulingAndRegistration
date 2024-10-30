using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Abstract.Services;
using EventSchedulingAndRegistration.Application.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.Cancels
{
    public class CancelCommandHandler(IUnitOfWork _unitOfWork, ITokenService _tokenService) : IRequestHandler<CancelCommand, DefaultGenericResponseDTO<Unit>>
    {
        public async Task<DefaultGenericResponseDTO<Unit>> Handle(CancelCommand request, CancellationToken cancellationToken)
        {
            var registration = await _unitOfWork.EventRegistration
                   .GetBaseQuery()
                   .FirstOrDefaultAsync(w => w.EventId == request.EventId && w.UserId == _tokenService.UserId);
            _unitOfWork.EventRegistration.Remove(registration);
            await _unitOfWork.SaveChangesAsync();
            return DefaultGenericResponseDTO<Unit>.SuccessResponse(Unit.Value);
        }
    }
}
