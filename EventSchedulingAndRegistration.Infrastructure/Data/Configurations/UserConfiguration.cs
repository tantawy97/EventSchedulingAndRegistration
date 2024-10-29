using EventSchedulingAndRegistration.Domain.Model;
using EventSchedulingAndRegistration.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventSchedulingAndRegistration.Infrastructure.Data.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

        builder.Property(c => c.Email).HasMaxLength(255);

        builder.HasIndex(c => c.Email).IsUnique();
        builder.ComplexProperty(
           o => o.PersonalInformation, nameBuilder =>
           {
               nameBuilder.Property(n => n.Address)
                   .HasColumnName(nameof(PersonalInformation.Address))
                   .HasMaxLength(100)
                   .IsRequired();

               nameBuilder.Property(n => n.PhoneNumber)
                   .HasColumnName(nameof(PersonalInformation.PhoneNumber))
                   .HasMaxLength(11)
                   .IsRequired();
           });
    }
}
