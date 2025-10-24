﻿using Microsoft.EntityFrameworkCore;
using Syac.Orders.Core.Application.Interfaces.Repositories;
using Syac.Orders.Core.Domain.Primitives;
using Syac.Orders.Core.Infraestructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Infraestructure.Persistence.Repositories
{
    public class Repository<TEntity, TId>(
        SyacOrdersDbContext context) : IRepository<TEntity, TId>
    where TEntity : EntityRoot<TId>, new()
    {

        #region Getters
        public virtual async Task<ResponseApiDataPaginate<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? where,
            Expression<Func<TEntity, TEntity>>? select,
            int actualPage, int pageSize)
        {
            List<TEntity> data = new List<TEntity>();
            
            IQueryable<TEntity> dbSet = context.Set<TEntity>().OrderByDescending(e => e.Id);

            if (where is not null)
                dbSet = dbSet.Where(where);
            if (select is not null)
                dbSet = dbSet.Select(select);


            var countData = dbSet.Count();
            int totalPages = (int)Math.Ceiling((double)countData / pageSize);
            int Index = (actualPage - 1) * pageSize;

            data = await dbSet.Skip(Index).Take(pageSize).ToListAsync();

            return new ResponseApiDataPaginate<TEntity> { Data = data, ActualPage = actualPage, CountData = countData, CountPages = totalPages };
            
        }

        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? where, Expression<Func<TEntity, TEntity>>? select)
        {
            List<TEntity> data = new List<TEntity>();
            IQueryable<TEntity> dbSet = context.Set<TEntity>().OrderByDescending(e => e.Id);
            if (where is not null)
                dbSet = dbSet.Where(where);
            if (select is not null)
                dbSet = dbSet.Select(select);

            data = await dbSet.ToListAsync();
            
            return data;
        }

        public virtual async Task<TEntity?> GetFirstAsync(TId id)
        {
            TEntity? entity;
            var dbSet = context.Set<TEntity>();
            entity = await dbSet.FindAsync(id);
            
            return entity;
        }

        public virtual async Task<TEntity?> GetFirstAsync(TId id, Expression<Func<TEntity, TEntity>> select)
        {
            TEntity? entity;
            entity = await context.Set<TEntity>().Where(e => e.Id!.Equals(id)).Take(1).Select(select).FirstOrDefaultAsync();
            return entity;
        }

        public virtual async Task<TEntity?> GetFirstAsync(Expression<Func<TEntity, bool>> firstOrDefault, Expression<Func<TEntity, TEntity>> select)
        {
            TEntity? entity;
            entity = await context.Set<TEntity>().Where(firstOrDefault).Take(1).Select(select).FirstOrDefaultAsync();
            return entity;
        }

        #endregion


        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            return entity;
        }


        public virtual async Task UpdateAsync(TEntity entity)
        {
            var dbSet = context.Set<TEntity>();
            var existingEntity = dbSet.Local.FirstOrDefault(x => x.Equals(entity));
            if (existingEntity is not null)
                dbSet.Local.Remove(existingEntity);

            var update = await Task.Run(() => dbSet.Update(entity));
        }


        public virtual async Task DeleteAsync(TId id)
        {
            var entityDelete = new TEntity { Id = id };
            await Task.Run(() =>
            {
                context.Set<TEntity>().Attach(entityDelete);
                context.Entry(entityDelete).Property(x => x.IsDeleted).CurrentValue = true;
            });
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            var dbSet = context.Set<TEntity>();
            await Task.Run(() => dbSet.Remove(entity));
        }

        public virtual async Task SaveChangesAsync() => await context.SaveChangesAsync();

    }
}
