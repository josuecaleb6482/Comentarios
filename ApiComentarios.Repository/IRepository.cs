using ApiComentarios.Abtractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        void Delete(int id);
        Task<TEntity> GetById(int id);
        Task<IList<TEntity>> GetList();
        Task<IEntity> Save(IEntity entity);
    }
}
