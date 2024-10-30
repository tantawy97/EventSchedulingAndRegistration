using EventSchedulingAndRegistration.Application.Abstract;
using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Account.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            RuleFor(w => w.Email)
           .NotEmpty()
           .NotNull()
           .WithMessage("Email Is Required")
           .Must(u => !_unitOfWork.User.AnyAsync(w => w.Email == u).Result)
           .WithMessage("Email Is Exist")
           .WithErrorCode("400");

            RuleFor(w => w.Name)
           .NotEmpty()
           .NotNull()
           .WithMessage("Name Is Required")
           .WithErrorCode("400");

            RuleFor(w => w.Password)
             .NotEmpty()
             .NotNull()
             .WithMessage("Password Is Required")
             .WithErrorCode("400");

            RuleFor(w => w.PersonalInformation.PhoneNumber)
             .NotEmpty()
             .NotNull()
             .WithMessage("PhoneNumber Is Required")
             .WithErrorCode("400");

            RuleFor(w => w.PersonalInformation.Address)
             .NotEmpty()
             .NotNull()
             .WithMessage("Address Is Required")
             .WithErrorCode("400");

        }
    }
}
