using ApiComentarios.Abtractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<IList<T>> GetList();
        Task<IEntity> Save(T entity);
    }
}
