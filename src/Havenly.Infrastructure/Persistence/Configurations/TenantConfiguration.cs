using Domain.Aggregates;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havenly.Infrastructure.Persistence.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(id => id.Value, value => new TenantId(value));

        builder.Property(x => x.UserId)
            .HasConversion(id => id.Value, value => new UserId(value));

        builder.Property(x => x.Age)
            .IsRequired();

        builder.Property(x => x.AverageSalary)
            .IsRequired();

        builder.Property(x => x.Deposit)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasKey(x => x.Id);
    }
}