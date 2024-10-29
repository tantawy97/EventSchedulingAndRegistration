using EventSchedulingAndRegistration.Application.Common;
using EventSchedulingAndRegistration.Application.Common.CQRS;
using MediatR;

namespace EventSchedulingAndRegistration.Application.BusinessLogic.Events.Commands.CreateEvents
{
    public class CreateEventCommand : ICommand<DefaultGenericResponseDTO<Unit>>
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime Date { get; set; }
        public string City { get; set; } = default!;
        public string StreetName { get; set; } = default!;

    }
}
