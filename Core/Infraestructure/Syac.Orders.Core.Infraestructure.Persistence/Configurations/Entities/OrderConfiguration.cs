using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syac.Orders.Core.Domain.Entities;

namespace Syac.Orders.Core.Infraestructure.Persistence.Configurations.Entities
{
    /// <summary>
    /// Configuración de entidad orden
    /// </summary>
    public class OrderConfiguration : BaseConfigurationEntity<Order, Guid>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "Orders");
            base.Configure(builder);

            builder.Property(e => e.CustomerId)
                .IsRequired()
                .HasComment("Id del cliente");

            builder.Property(e => e.State)
                .IsRequired(false)
                .HasDefaultValue(null)
                .HasComment("Indica el estado del pedido, siendo null para en proceso, false para cancelado y true confirmado");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()")
                .HasComment("Indica la fecha y hora en que se creo el pedido");

            builder.HasMany(e => e.OrderProducts).WithOne(e => e.Order)
                .HasForeignKey(e => e.OrderId).HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
