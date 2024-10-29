using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventSchedulingAndRegistration.Infrastructure.Data.Configurations;
public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title).HasMaxLength(100).IsRequired();

        builder.Property(c => c.Description).HasMaxLength(255);

        builder.HasIndex(c => c.Title).IsUnique();
        builder.ComplexProperty(
           o => o.Location, nameBuilder =>
           {
               nameBuilder.Property(n => n.City)
                   .HasColumnName(nameof(Location.City))
                   .HasMaxLength(100)
                   .IsRequired();

               nameBuilder.Property(n => n.StreetName)
                   .HasColumnName(nameof(Location.StreetName))
                   .HasMaxLength(11)
                   .IsRequired();
           });
    }
}
