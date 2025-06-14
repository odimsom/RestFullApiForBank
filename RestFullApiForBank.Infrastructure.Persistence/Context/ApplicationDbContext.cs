using Microsoft.EntityFrameworkCore;
using RestFullApiForBank.Core.Application.Interfaces;
using RestFullApiForBank.Core.Domain.Common;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeSerivce _dateTimeService;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeSerivce dateTime) : base(options)
        {
            _dateTimeService = dateTime;
        }
        public DbSet<Cliente> Clientes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                var entityState = entry.State switch
                {
                    EntityState.Added => entry.Entity.Created = _dateTimeService.NowUtc,
                    EntityState.Modified => entry.Entity.LastModified = _dateTimeService.NowUtc
                }; 
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
