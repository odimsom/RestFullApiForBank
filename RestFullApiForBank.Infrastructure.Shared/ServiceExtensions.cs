using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Infrastructure.Shared.Services;

namespace RestFullApiForBank.Infrastructure.Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
