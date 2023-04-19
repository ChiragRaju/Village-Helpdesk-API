using System.Diagnostics.CodeAnalysis;
using HelpDesk.Application.Interfaces.Services;

namespace HelpDesk.Infrastructure.Services;

[ExcludeFromCodeCoverage]
public class DateTimeService : IDateTimeService
{
    public DateTime UtcNow => DateTime.UtcNow;
}
