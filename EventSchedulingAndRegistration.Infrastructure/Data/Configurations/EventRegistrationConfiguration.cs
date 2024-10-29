using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventSchedulingAndRegistration.Infrastructure.Data.Configurations;
public class EventRegistrationConfiguration : IEntityTypeConfiguration<EventRegistration>
{
    public void Configure(EntityTypeBuilder<EventRegistration> builder)
    {
        builder.HasKey(c => c.Id);
    }
}
