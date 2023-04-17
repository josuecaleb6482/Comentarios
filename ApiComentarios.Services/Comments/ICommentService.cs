using ApiComentarios.DTOSs;
using ApiComentarios.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services
{
    public interface ICommentService
    {
        Task<Comments> SaveComment(CommentDTO comentario, int id = 0);
        Task<IList<Comments>> GetComments(int pageNumber, int pageSize);
        Task<CommentDTO> GetCommentById(int comentarioId);
        Task DeleteComment(int comentarioId);
        Task<IList<Comments>> FindComment(string text);
    }
}