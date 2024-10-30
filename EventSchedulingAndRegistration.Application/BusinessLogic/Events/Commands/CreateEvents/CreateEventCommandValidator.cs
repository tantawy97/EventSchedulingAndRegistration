using EventSchedulingAndRegistration.Application.Abstract;
using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Commands.CreateEvents
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            RuleFor(w => w.Title)
           .NotEmpty()
           .NotNull()
           .WithMessage("Title Is Required")
           .Must(u => !_unitOfWork.User.AnyAsync(w => w.Email == u).Result)
           .WithMessage("Title Is Exist")
           .WithErrorCode("400");

            RuleFor(w => w.Description)
           .NotEmpty()
           .NotNull()
           .WithMessage("Description Is Required")
           .WithErrorCode("400");

            RuleFor(w => w.Date)
             .NotEmpty()
             .NotNull()
             .WithMessage("Date Is Required")
             .WithErrorCode("400");

            RuleFor(w => w.Location.City)
             .NotEmpty()
             .NotNull()
             .WithMessage("City Is Required")
             .WithErrorCode("400");

            RuleFor(w => w.Location.StreetName)
             .NotEmpty()
             .NotNull()
             .WithMessage("StreetName Is Required")
             .WithErrorCode("400");

        }
    }
}
