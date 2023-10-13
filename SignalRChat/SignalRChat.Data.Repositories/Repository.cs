using Microsoft.EntityFrameworkCore;
using SignalRChat.Data.Abstractions;
using SignalRChat.DataBase;
using SignalRChat.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRChat.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly SignalRChatDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(SignalRChatDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual IQueryable<T>? Get()
        {
            var entities = _dbSet
                .AsNoTracking()
                .AsQueryable();

            return entities;

        }

        public virtual async Task<T?> GetEntityByIdAsync(Guid id)
        {
            var entity = await _dbSet
                    .FirstOrDefaultAsync(entity => entity.Id.Equals(id));

            return entity;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
