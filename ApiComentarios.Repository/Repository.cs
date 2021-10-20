using ApiComentarios.Abtractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Repository
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


        public async void Delete(int id)
        {
            var comentario = await _context.Set<TEntity>().FindAsync(id);

            _context.Remove(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEntity> Save(IEntity entity)
        {
            if (entity.id != 0)
                _context.Set<IEntity>().Add(entity);
            else
                _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> GetList()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
