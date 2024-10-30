using EventSchedulingAndRegistration.Application.BusinessLogic.Account.Login;
using EventSchedulingAndRegistration.Application.BusinessLogic.Account.Register;
using EventSchedulingAndRegistration.Application.BusinessLogic.Events.Commands.CreateEvents;
using EventSchedulingAndRegistration.Application.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSchedulingAndRegistration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMediator _mediator) : ControllerBase
    {
        [HttpPost("Register")]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<string>), 200)]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("Login")]
        [ProducesResponseType(typeof(DefaultGenericResponseDTO<string>), 200)]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
