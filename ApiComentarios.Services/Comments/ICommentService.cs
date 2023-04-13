using ApiComentarios.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services
{
    public interface ICommentService
    {
        Task<Comentario> CreateComment(Comentario comentario);
        Task<IList<Comentario>> GetComments(int pageNumber, int pageSize);
        Task<Comentario> GetCommentById(int comentarioId);
        Task DeleteComment(int comentarioId);
        Task<IList<Comentario>> FindComment(string text);
    }
}