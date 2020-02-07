using Microsoft.EntityFrameworkCore;
using MusicService.API.Data;
using MusicService.Domain.Interfaces;
using MusicService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicService.API.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly MusicServiceContext _musicServiceContext;

        public Repository(MusicServiceContext context)
        {
            _musicServiceContext = context;
        }

        public virtual async Task<T> GetById(string id)
        {
            return await _musicServiceContext.Set<T>().FindAsync(Guid.Parse(id));
        }

        // get an IQueryAble: to manipulate with deferred execution
        public virtual IQueryable<T> GetAll()
        {
            // Entities won't be manipulated directly on this set --> faster with AsNoTracking()
            return _musicServiceContext.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }


        public virtual IQueryable<T> GetFiltered(Expression<Func<T, bool>> predicate)
        {
            return _musicServiceContext.Set<T>()
                   .Where(predicate).AsNoTracking();
        }

        public async virtual Task<IEnumerable<T>> ListFiltered(Expression<Func<T, bool>> predicate)
        {
            return await GetFiltered(predicate).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            _musicServiceContext.Set<T>().Add(entity);
            try
            {
                await _musicServiceContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _musicServiceContext.Entry(entity).State = EntityState.Modified;
            try
            {
                await _musicServiceContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _musicServiceContext.Set<T>().Remove(entity);
            try
            {
                await _musicServiceContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }
            return entity;
        }

        public async Task<T> Delete(string id)
        {
            var entity = await GetById(id);
            if (entity == null) return null;
            return await Delete(entity);
        }
    }
}