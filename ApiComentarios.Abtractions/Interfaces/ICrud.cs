using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Abtractions.Interfaces
{
    public interface ICrud<T> where T : class, IEntity
    {
        Task<IEntity> Save(T entity);
        Task<IList<T>> GetList();
        Task<T> GetById(int id);
        Task Delete(int id);
    }
}
