namespace EventSchedulingAndRegistration.Application.Common.DTOs
{
    public record EventDto(
     Guid Id,
     string Title,
     string Description,
     LocationDto Location,
     DateTime Date);
}
