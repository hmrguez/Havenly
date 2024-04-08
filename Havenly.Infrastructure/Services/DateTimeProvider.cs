using Havenly.Application.Common.Interfaces.Services;

namespace Havenly.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}