using EventSchedulingAndRegistration.Application.Abstract.Services;
using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.BusinessLogic.Account.Register;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Domain.ValueObject;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Account.Login
{
    public class LoginCommandHandler(IUnitOfWork _unitOfWork, ITokenService _tokenService) : ICommandHandler<LoginCommand, GetLoginResult>
    {
        public async Task<GetLoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
          var user = await _unitOfWork.User.GetBaseQuery(true).FirstOrDefaultAsync(w => w.Email == request.Email && w.Password == request.Password);
            var token = _tokenService.CreateJwtToken(user);
            return new GetLoginResult(DefaultGenericResponseDTO<string>.SuccessResponse(token));

        }
    }
}
