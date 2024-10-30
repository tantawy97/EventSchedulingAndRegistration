
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common.DTOs;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Account.Register
{
    public record GetRegisterResult(DefaultGenericResponseDTO<string> register);

    public record RegisterCommand(string Email, string Name, string Password, PersonalInformationDto PersonalInformation) : ICommand<GetRegisterResult>;
}
