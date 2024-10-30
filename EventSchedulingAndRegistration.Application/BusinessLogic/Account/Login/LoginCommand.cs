using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Account.Login
{
    public record GetLoginResult(DefaultGenericResponseDTO<string> login);

    public record LoginCommand(string Email, string Password) : ICommand<GetLoginResult>;

}
