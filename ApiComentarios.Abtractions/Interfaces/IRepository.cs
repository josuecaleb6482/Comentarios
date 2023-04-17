using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace ApiComentarios.Abtractions.Interfaces
{
    public interface IRepository<T> : ICrud<T> where T : class, IEntity
    {
        Task<IList<T>> GetByPage(int pageNumber, int sizePage);
        Task<IList<T>> SearchList(Expression<Func<T, bool>> criteria);
        Task<T> Find(Expression<Func<T, bool>> criteria);
    }
}
