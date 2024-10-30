using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Abstract.Services;
using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Domain.ValueObject;
using MediatR;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Account.Register
{
    public class RegisterCommandHandler(IUnitOfWork _unitOfWork,ITokenService _tokenService) : ICommandHandler<RegisterCommand, GetRegisterResult>
    {
        public async Task<GetRegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var personalInformation = PersonalInformation.Of(request.PersonalInformation.Address, request.PersonalInformation.PhoneNumber);
            var user = User.Create(request.Name, request.Email, request.Password, personalInformation);
            await _unitOfWork.User.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();
          var token =  _tokenService.CreateJwtToken(user);
            return new GetRegisterResult(DefaultGenericResponseDTO<string>.SuccessResponse(token));

        }
    }
}
