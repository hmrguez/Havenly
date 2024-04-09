using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havenly.Infrastructure.Persistence.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => new PropertyId(value));

        builder.OwnsOne(p => p.Address, a =>
        {
            a.Property(p => p.Street).HasColumnName("Street");
            a.Property(p => p.City).HasColumnName("City");
            a.Property(p => p.ZipCode).HasColumnName("ZipCode");
            a.Property(p => p.Country).HasColumnName("Country");
        });

        builder.Property(x => x.Bedrooms)
            .IsRequired();

        builder.Property(x => x.Bathrooms)
            .IsRequired();

        builder.Property(x => x.SquareFootage)
            .IsRequired();

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.OwnerId)
            .HasConversion(id => id.Value, value => new OwnerId(value));

        builder.HasOne(x => x.Owner)
            .WithMany(o => o.Properties)
            .HasForeignKey(x => x.OwnerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Amenities)
            .WithMany(a => a.Properties)
            .UsingEntity(j => j.ToTable("PropertyAmenities"));

        builder.HasKey(x => x.Id);
    }
}