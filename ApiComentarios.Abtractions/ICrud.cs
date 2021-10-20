using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Abtractions
{
    public interface ICrud<T> where T : class, IEntity
    {
        Task<T> Save(T entity);
        Task<IList<T>> GetList();
        Task<T> GetById(int id);
        void Delete(int id);
    }
}
