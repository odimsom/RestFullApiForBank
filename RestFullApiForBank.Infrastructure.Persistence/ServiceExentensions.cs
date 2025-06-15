using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Infrastructure.Persistence.Context;
using RestFullApiForBank.Infrastructure.Persistence.Repositories;

namespace RestFullApiForBank.Infrastructure.Persistence
{
    public static class ServiceExentensions
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(opt => 
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"), b => 
                    b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyResposiotryAsync<>));
            #endregion
        }
    }
}
