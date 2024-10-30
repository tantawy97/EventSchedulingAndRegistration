using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllUsersByEventId
{
    public class GetAllUsersByEventIdQueryValidator : AbstractValidator<GetAllUsersByEventIdQuery>
    {
        public GetAllUsersByEventIdQueryValidator()
        {
            RuleFor(w => w.EventId)
           .NotEmpty()
           .NotNull()
           .WithMessage("Event Id Is Required")
           .WithErrorCode("400");
        }
    }
}
