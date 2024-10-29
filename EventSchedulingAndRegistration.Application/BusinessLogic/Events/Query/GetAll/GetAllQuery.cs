using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Application.Pagination;
using MediatR;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Query.GetAll
{
    public record GetEventsResult(DefaultGenericResponseDTO<List<EventDto>> events);
    public record GetAllQuery(PaginationRequest PaginationRequest) : IQuery<GetEventsResult>;
}
