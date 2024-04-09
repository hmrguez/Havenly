using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havenly.Infrastructure.Persistence.Configurations;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => new OwnerId(value));

        builder.Property(x => x.UserId)
            .HasConversion(id => id.Value, value => new UserId(value));

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        
        builder.HasKey(x => x.Id);
        
    }
}