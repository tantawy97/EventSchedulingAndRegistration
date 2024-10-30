using EventSchedulingAndRegistration.Application.BusinessLogic.Account.Register;
using EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.Cancels;
using EventSchedulingAndRegistration.Application.BusinessLogic.Events.Commands.CreateEvents;
using EventSchedulingAndRegistration.Application.BusinessLogic.Events.Query.GetAll;
using EventSchedulingAndRegistration.Application.BusinessLogic.Events.Query.GetById;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.DTOs;
using EventSchedulingAndRegistration.Application.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSchedulingAndRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class EventController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<List<EventDto>>), 200)]

        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest request)
        {
            var result = await _mediator.Send(new GetAllQuery(request));
            return Ok(result);
        }     
        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<EventDto>), 200)]
        public async Task<IActionResult> GetById([FromRoute] GetByIdQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }      
        [HttpPost]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<Unit>), 200)]
        public async Task<IActionResult> Create([FromBody] CreateEventCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
