using EventSchedulingAndRegistration.Application.Abstract;
using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Account.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            RuleFor(w => w)
            .Must(u => _unitOfWork.User.AnyAsync(w => w.Email == u.Email && w.Password == u.Password).Result)
           .WithMessage("Email Or Password Is Not Correct")
           .WithErrorCode("400");  
            
            RuleFor(w => w.Email)
           .NotEmpty()
           .NotNull()
           .WithMessage("Email Is Required")
           .WithErrorCode("400");

            RuleFor(w => w.Password)
             .NotEmpty()
             .NotNull()
             .WithMessage("Password Is Required")
             .WithErrorCode("400");

        }
    }
}
