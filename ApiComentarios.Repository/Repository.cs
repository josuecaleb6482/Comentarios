using ApiComentarios.Abtractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var entity = await _context.Set<TEntity>().FindAsync(id);

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEntity> Save(TEntity entity)
        {
            if (entity.id == 0)
                _context.Set<TEntity>().Add(entity);
            else
                _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> GetList()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
