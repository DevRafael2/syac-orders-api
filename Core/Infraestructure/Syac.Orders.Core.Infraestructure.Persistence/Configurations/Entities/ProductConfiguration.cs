using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syac.Orders.Core.Domain.Entities;

namespace Syac.Orders.Core.Infraestructure.Persistence.Configurations.Entities
{
    /// <summary>
    /// Configuración de productos
    /// </summary>
    public class ProductConfiguration : BaseConfigurationEntity<Product, short>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "Stock");
            base.Configure(builder);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Nombre del producto");

            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(8,2)")
                .HasComment("Precio del producto");

            builder.HasMany(e => e.OrderProducts).WithOne(e => e.Product)
                .HasForeignKey(e => e.ProductId).HasPrincipalKey(e => e.Id);

            builder.HasData(SeedProducts);
        }

        /// <summary>
        /// Semilla de productos
        /// </summary>
        private static readonly List<Product> SeedProducts = [
                new Product { Id = 1, Name = "Teclado mecánico", Price = 400 },
                new Product { Id = 2, Name = "Mouse ergonómico", Price = 150 },
                new Product { Id = 3, Name = "Pantalla 27 pulgadas", Price = 1200 },
                new Product { Id = 4, Name = "Cable HDMI", Price = 20 },
                new Product { Id = 5, Name = "Silla gamer", Price = 600 },
            ];
    }
}
