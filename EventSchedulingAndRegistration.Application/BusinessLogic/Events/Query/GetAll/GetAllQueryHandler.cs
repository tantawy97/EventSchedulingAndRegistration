using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Application.Common.Mappers;
using Microsoft.EntityFrameworkCore;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Query.GetAll
{
    public class GetAllQueryHandler(IUnitOfWork _unitOfWork) : IQueryHandler<GetAllQuery, GetEventsResult>
    {
        public async Task<GetEventsResult> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Event.GetBaseQuery(true)
                           .Skip(request.PaginationRequest.PageSize * request.PaginationRequest.PageIndex)
                           .Take(request.PaginationRequest.PageSize)
                           .ToListAsync();

            var totalCount = await _unitOfWork.Event.CountAllAsync();

            return new GetEventsResult(
               DefaultGenericResponseDTO<List<EventDto>>.SuccessResponse(
                    events.ToDtoList(),
                    totalCount
                 ));

        }
    }
}
