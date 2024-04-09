using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havenly.Infrastructure.Persistence.Configurations;

public class LeaseConfiguration : IEntityTypeConfiguration<Lease>
{
    public void Configure(EntityTypeBuilder<Lease> builder)
    {
        builder.Property(x => x.PropertyId)
            .HasConversion(id => id.Value, value => new PropertyId(value));

        builder.Property(x => x.TenantId)
            .HasConversion(id => id.Value, value => new TenantId(value));

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.Property(x => x.Rent)
            .IsRequired();

        builder.Property(x => x.Deposit)
            .IsRequired();

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Property)
            .WithMany().HasForeignKey(x => x.PropertyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Tenant)
            .WithMany()
            .HasForeignKey(x => x.TenantId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}