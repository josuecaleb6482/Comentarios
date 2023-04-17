using ApiComentarios.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services
{
    public interface ICommentService
    {
        Task<Comments> SaveComment(Comments comentario);
        Task<IList<Comments>> GetComments(int pageNumber, int pageSize);
        Task<Comments> GetCommentById(int comentarioId);
        Task DeleteComment(int comentarioId);
        Task<IList<Comments>> FindComment(string text);
    }
}