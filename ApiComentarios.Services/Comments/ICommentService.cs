using ApiComentarios.DTOSs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services
{
    public interface ICommentService
    {
        Task<CommentDTO> SaveComment(CommentDTO comentario);
        Task<IList<CommentDTO>> GetComments(int pageNumber, int pageSize);
        Task<CommentDTO> GetCommentById(int comentarioId);
        Task DeleteComment(int comentarioId);
        Task<IList<CommentDTO>> FindComment(string text);
    }
}