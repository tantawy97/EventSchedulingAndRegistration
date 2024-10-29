using EventSchedulingAndRegistration.Domain.Abstract;
using EventSchedulingAndRegistration.Domain.ValueObject;

namespace EventSchedulingAndRegistration.Domain.Model
{
    public class Event : Entity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Location Location { get; set; } = default!;
        public DateTime Date { get; set; }
        private readonly List<EventRegistration> _eventRegistrations = new();
        public IReadOnlyList<EventRegistration> EventRegistrations => _eventRegistrations.AsReadOnly();
        public static Event Create(string title, string description, Location location,DateTime date)
        {
            var @event = new Event
            {
                Title = title,
                Description = description,
                Location = location,
                Date = date,
            };
            return @event;

        }
    }
}
