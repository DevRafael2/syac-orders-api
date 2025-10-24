using Microsoft.EntityFrameworkCore;

namespace Syac.Orders.Core.Infraestructure.Persistence.Context
{
    /// <summary>
    /// Contexto de base de datos
    /// </summary>
    /// <param name="options">Opciones o configuración del contexto</param>
    public class SyacOrdersDbContext(DbContextOptions<SyacOrdersDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SyacOrdersDbContext).Assembly);
        }
    }
}
