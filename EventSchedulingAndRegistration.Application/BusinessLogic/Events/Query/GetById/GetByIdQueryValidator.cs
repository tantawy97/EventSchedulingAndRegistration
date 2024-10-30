using EventSchedulingAndRegistration.Application.Abstract;
using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Query.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdQueryValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            RuleFor(w => w.Id)
           .NotEmpty()
           .NotNull()
           .WithMessage("Id Is Required")
           .Must(u => _unitOfWork.Event.AnyAsync(w => w.Id == u).Result)
           .WithMessage("Id Is Not Exist")
           .WithErrorCode("404");
        }
    }
}
