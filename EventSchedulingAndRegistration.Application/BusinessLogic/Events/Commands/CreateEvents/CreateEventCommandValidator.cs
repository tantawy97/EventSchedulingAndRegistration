using FluentValidation;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Commands.CreateEvents
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        public CreateEventCommandValidator()
        {
        }
    }
}
