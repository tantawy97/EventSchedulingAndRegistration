using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Query.GetById
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
        }
    }
}
