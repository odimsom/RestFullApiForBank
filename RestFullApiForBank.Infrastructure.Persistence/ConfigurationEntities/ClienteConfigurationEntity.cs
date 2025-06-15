using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestFullApiForBank.Core.Domain.Entities;

namespace RestFullApiForBank.Infrastructure.Persistence.ConfigurationEntities
{
    public class ClienteConfigurationEntity : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nombre)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(c => c.FechaDeNacimineto)
                .IsRequired();
            
            builder.Property(c => c.Telefono)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(100);
            
            builder.Property(c => c.Direccion)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(c => c.Edad);

            builder.Property(c => c.CreatedBy)
                .HasMaxLength(30);

            builder.Property(c => c.LatModifiedBy)
                .HasMaxLength(30);
        }
    }
}
