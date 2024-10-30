using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Application.Common.Exceptions;
using EventSchedulingAndRegistration.Application.Common.Mappers;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Query.GetById
{
    public class GetByIdQueryHandler(IUnitOfWork _unitOfWork) : IQueryHandler<GetByIdQuery, GetEventByIdResult>
    {
        public async Task<GetEventByIdResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var @event = await _unitOfWork.Event.FindByIdAsync(request.Id);
            if (@event is null)
            {
                throw new EventNotFoundException(request.Id);
            }
            return new GetEventByIdResult(DefaultGenericResponseDTO<EventDto>.SuccessResponse(@event.ToDto()));
        }
    }
}
