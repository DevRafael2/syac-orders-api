using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syac.Orders.Core.Domain.Entities;

namespace Syac.Orders.Core.Infraestructure.Persistence.Configurations.Entities
{
    /// <summary>
    /// Configuración de usuario
    /// </summary>
    public class CustomerConfiguration : BaseConfigurationEntity<Customer, Guid>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Users");
            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Nombre del cliente");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(350)
                .HasComment("Correo del usuario");

            builder.Property(e => e.IdentityNumber)
                .IsRequired()
                .HasComment("Numero de identificación del usuario");

            builder.HasMany(e => e.Orders).WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId).HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(SeedCustomers);
        }

        /// <summary>
        /// Semilla de clientes
        /// </summary>
        public static readonly List<Customer> SeedCustomers = [
                new Customer { Id = Guid.Parse("b29c4c7f-ea5d-431f-bca6-e650742cfb9f"), Name = "Syac", IdentityNumber = 12345678, Email = "customer@syac.com" },
                new Customer { Id = Guid.Parse("1b4e28ba-2fa1-11d2-883f-0016d3cca427"), Name = "Rafael Cascante", IdentityNumber = 1005714857, Email = "rgcascante@outlook.com" },
                new Customer { Id = Guid.Parse("3fedd6a9-4fc4-4d65-9e73-7ab16e55f2b9"), Name = "Sara Giraldo", IdentityNumber = 12345678, Email = "sara@gmail.com" },
            ];
    }
}
