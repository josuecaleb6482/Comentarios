using ApiComentarios.Abtractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiComentarios.Repositories
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        public readonly TContext _context;
        public Repository(TContext context)
        {
            _context = context;
        }


        public async Task Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEntity> Save(TEntity entity)
        {
            if (entity.Id == 0)
                _context.Set<TEntity>().Add(entity);
            else
                _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> GetList()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<IList<TEntity>> GetByPage(int pageNumber, int sizePage)
        {
            return await _context.Set<TEntity>()
            .OrderBy(p => p.Id)
            .Skip((pageNumber - 1) * sizePage)
            .Take(sizePage)
            .ToListAsync();
        }

        public async Task<IList<TEntity>> SearchList(Expression<Func<TEntity, bool>> criteria)
        {
            return await _context.Set<TEntity>()
            .Where(criteria)
            .ToListAsync();
        }

        public async Task<TEntity> Find(Expression<Func<TEntity, bool>> criteria)
        {
            return await _context.Set<TEntity>()
            .Where(criteria)
            .FirstOrDefaultAsync();
        }
    }
}
