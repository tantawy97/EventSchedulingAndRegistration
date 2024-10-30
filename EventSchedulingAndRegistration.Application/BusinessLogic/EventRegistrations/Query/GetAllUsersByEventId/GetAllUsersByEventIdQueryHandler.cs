using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllEventByUserId;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Application.Common.Mappers;
using Microsoft.EntityFrameworkCore;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllUsersByEventId
{
    public class GetAllUsersByEventIdQueryHandler(IUnitOfWork _unitOfWork) : IQueryHandler<GetAllUsersByEventIdQuery, GetUsersByEventIdResult>
    {
        public async Task<GetUsersByEventIdResult> Handle(GetAllUsersByEventIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.EventRegistration.GetBaseQuery(true)
                .Include(w => w.User)
                .Where(w => w.EventId == request.EventId)
                .Select(w => w.User).ToListAsync();

            return new GetUsersByEventIdResult(
                DefaultGenericResponseDTO<List<UserDto>>
                .SuccessResponse(users.ToDtoList()));
        }
    }
}
