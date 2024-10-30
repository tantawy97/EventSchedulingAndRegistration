using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Application.Common.Mappers;
using Microsoft.EntityFrameworkCore;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllEventByUserId
{
    public class GetAllEventByUserIdQueryHandler(IUnitOfWork _unitOfWork) : IQueryHandler<GetAllEventByUserIdQuery, GetEventsByUserIdResult>
    {
        public async Task<GetEventsByUserIdResult> Handle(GetAllEventByUserIdQuery request, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.EventRegistration.GetBaseQuery(true)
                .Include(w => w.Event)
                .Where(w => w.UserId == request.UserId)
                .Select(w => w.Event).ToListAsync();

            return new GetEventsByUserIdResult(
                DefaultGenericResponseDTO<List<EventDto>>
                .SuccessResponse(events.ToDtoList()));
        }
    }
}
