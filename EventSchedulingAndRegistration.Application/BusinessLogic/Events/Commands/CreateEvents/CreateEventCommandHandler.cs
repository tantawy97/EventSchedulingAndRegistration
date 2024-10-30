using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Domain.ValueObject;
using MediatR;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Commands.CreateEvents
{
    public class CreateEventCommandHandler(IUnitOfWork _unitOfWork) :
        ICommandHandler<CreateEventCommand, DefaultGenericResponseDTO<Unit>>
    {
        public async Task<DefaultGenericResponseDTO<Unit>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var location = Location.Of(request.Location.City, request.Location.StreetName);
            var @event= Event.Create(request.Title, request.Description, location, request.Date);

          await  _unitOfWork.Event.CreateAsync(@event);
          await  _unitOfWork.SaveChangesAsync();
            return DefaultGenericResponseDTO<Unit>.SuccessResponse(Unit.Value);
        }
}
}
