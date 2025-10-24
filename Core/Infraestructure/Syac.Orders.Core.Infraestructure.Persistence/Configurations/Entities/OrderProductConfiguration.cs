using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syac.Orders.Core.Domain.Entities;
using Syac.Orders.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Infraestructure.Persistence.Configurations.Entities
{
    /// <summary>
    /// Configuración de OrderProduct
    /// </summary>
    public class OrderProductConfiguration : BaseConfigurationEntity<OrderProduct, long>
    {
        public override void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProducts", "Orders");
            base.Configure(builder);

            builder.Property(e => e.OrderId)
                .IsRequired()
                .HasComment("Id de la orden");

            builder.Property(e => e.ProductId)
                .IsRequired()
                .HasComment("Id del producto relacionado");

            builder.Property(e => e.Amount)
                .IsRequired()
                .HasDefaultValue(1)
                .HasComment("Cantidad solicitada del producto");

            builder.HasIndex(e => new { e.OrderId, e.ProductId }).IsUnique();

            builder.HasOne(e => e.Order).WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.OrderId).HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Product).WithMany(e => e.OrderProducts)
                .HasForeignKey(e => e.ProductId).HasPrincipalKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
