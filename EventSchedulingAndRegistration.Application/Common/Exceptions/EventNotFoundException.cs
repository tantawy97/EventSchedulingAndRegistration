namespace EventSchedulingAndRegistration.Application.Common.Exceptions;
public class EventNotFoundException : NotFoundException
{
    public EventNotFoundException(Guid id) : base("Event", id)
    {
    }
}
