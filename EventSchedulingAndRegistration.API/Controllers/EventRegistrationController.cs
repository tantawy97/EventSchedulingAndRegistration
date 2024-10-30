using EventSchedulingAndRegistration.Application.BusinessLogic.Account.Register;
using EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.Cancels;
using EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.RegisterEvents;
using EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllEventByUserId;
using EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllUsersByEventId;
using EventSchedulingAndRegistration.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSchedulingAndRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventRegistrationController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("Register")]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<Unit>), 200)]
        public async Task<IActionResult> Register([FromBody] RegisterEventCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("Cancel")]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<Unit>), 200)]
        public async Task<IActionResult> Cancel([FromBody] CancelCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        } 
        [HttpGet("GetAllEventsByUserId/{UserId}")]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<Unit>), 200)]
        public async Task<IActionResult> GetAllEventByUserId([FromRoute] GetAllEventByUserIdQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("GetAllUsersByEventId/{EventId}")]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<Unit>), 200)]
        public async Task<IActionResult> GetAllUsersByEventId([FromRoute] GetAllUsersByEventIdQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
