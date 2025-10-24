using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Syac.Orders.Core.Domain.Primitives;

namespace Syac.Orders.Core.Infraestructure.Persistence.Configurations
{
    /// <summary>
    /// Clase base de configuración para entidades
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public class BaseConfigurationEntity<TEntity, TId> : IEntityTypeConfiguration<TEntity> where TEntity : EntityRoot<TId>
    {
        /// <summary>
        /// Metodo que implementa configuraciones basicas
        /// </summary>
        /// <param name="builder">Model Builder</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            List<Type> numericIds = [typeof(byte), typeof(short), typeof(int), typeof(long)];
            builder.HasKey(x => x.Id);
            if (numericIds.Contains(typeof(TId)))
                builder.Property(x => x.Id).UseIdentityColumn();
            else if (typeof(TId) == typeof(Guid))
                builder.Property(x => x.Id).HasColumnType("UNIQUEIDENTIFIER")
                    .HasDefaultValueSql("NEWSEQUENTIALID()");

                builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Id).HasComment("Id del registro");
            builder.Property(e => e.IsDeleted).HasComment("Indica si el registro ha sido eliminado");
        }
    }
}
