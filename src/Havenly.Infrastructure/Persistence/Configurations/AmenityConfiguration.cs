using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havenly.Infrastructure.Persistence.Configurations;

public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => new AmenityId(value));

        builder.HasKey(x => x.Id);
    }
}