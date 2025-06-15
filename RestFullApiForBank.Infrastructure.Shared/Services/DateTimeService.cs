using RestFullApiForBank.Core.Application.Interfaces;

namespace RestFullApiForBank.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}