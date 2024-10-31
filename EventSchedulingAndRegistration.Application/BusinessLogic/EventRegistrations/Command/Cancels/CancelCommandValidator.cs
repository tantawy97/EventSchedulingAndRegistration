using EventSchedulingAndRegistration.Application.Abstract;
using EventSchedulingAndRegistration.Application.Abstract.Services;
using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Command.Cancels
{
    public class CancelCommandValidator : AbstractValidator<CancelCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public CancelCommandValidator(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            RuleFor(w => w)
           .NotEmpty()
           .NotNull()
           .WithMessage("Event Id Is Required")
           .Must(u => _unitOfWork.EventRegistration.AnyAsync(w => w.EventId == u.EventId && w.UserId == _tokenService.UserId).Result)
           .WithMessage("User Not Registered For Event")
           .WithErrorCode("400");
        }
    }
}
