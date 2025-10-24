﻿using Microsoft.Extensions.DependencyInjection;
using Syac.Orders.Core.Application.Interfaces.Repositories;
using Syac.Orders.Core.Application.Interfaces.UnitOfWork;
using Syac.Orders.Core.Domain.Primitives;
using Syac.Orders.Core.Infraestructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Infraestructure.Persistence.Repositories
{
    /// <summary>
    /// Unidad de trabajo
    /// </summary>
    internal class UnitOfWork(
        IServiceProvider serviceProvider,
        SyacOrdersDbContext context) : IUnitOfWork
    {
        /// <summary>
        /// Diccionario de repositorios
        /// </summary>
        private Dictionary<Type, object> Repositories { get; set; } = new Dictionary<Type, object>();

        /// <inheritDoc />
        public IRepository<TEntity, TId> GetRepository<TEntity, TId>()
            where TEntity : EntityRoot<TId>, new()
        {
            if (Repositories.ContainsKey(typeof(TEntity)))
                return (IRepository<TEntity, TId>)Repositories[typeof(TEntity)];

            var repository = serviceProvider.GetRequiredService<IRepository<TEntity, TId>>();
            Repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        /// <inheritDoc />
        public TRepository GetRepository<TRepository, TEntity, TId>()
            where TEntity : EntityRoot<TId>, new()
            where TRepository : notnull, IRepository<TEntity, TId>
        {
            if (Repositories.ContainsKey(typeof(TRepository)))
                return (TRepository)Repositories[typeof(TRepository)];

            var repository = serviceProvider.GetRequiredService<TRepository>();
            Repositories.Add(typeof(TRepository), repository!);
            return repository;
        }

        /// <inheritDoc />
        public async Task CompleteAsync() =>
            await context.SaveChangesAsync();
    }
}
