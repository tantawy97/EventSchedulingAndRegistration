using EventSchedulingAndRegistration.Application.Abstract.Services;
using EventSchedulingAndRegistration.Application.Abstract;
using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.EventRegistrations.Query.GetAllEventByUserId
{
    public class GetAllEventByUserIdQueryValidator : AbstractValidator<GetAllEventByUserIdQuery>
    {
        public GetAllEventByUserIdQueryValidator()
        {
            RuleFor(w => w.UserId)
           .NotEmpty()
           .NotNull()
           .WithMessage("User Id Is Required")
           .WithErrorCode("400");
        }
    }
}
