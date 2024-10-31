using EventSchedulingAndRegistration.Application.Abstract.Services;
using EventSchedulingAndRegistration.Application.Abstract;
using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.RegisterEvents
{
    public class RegisterEventCommandValidator : AbstractValidator<RegisterEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public RegisterEventCommandValidator(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            RuleFor(w => w)
           .NotEmpty()
           .NotNull()
           .WithMessage("Event Id Is Required")
           .Must(u => !_unitOfWork.EventRegistration.AnyAsync(w => w.EventId == u.EventId && w.UserId == _tokenService.UserId).Result)
           .WithMessage("User Already Registered For Event")
           .WithErrorCode("400");
        }
    }
}
