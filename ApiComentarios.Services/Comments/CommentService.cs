using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services
{
    public class CommentServices : ICommentService
    {
        private readonly IRepository<Comentario> _comentarioRepository;

        public CommentServices(IRepository<Comentario> comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public async Task<Comentario> CreateComment(Comentario comentario)
        {
            return (Comentario)await _comentarioRepository.Save(comentario);
        }

        public async Task<IList<Comentario>> GetComments()
        {
            return await _comentarioRepository.GetList();
        }

        public async Task<Comentario> GetCommentById(int comentarioId)
        {
            return await _comentarioRepository.GetById(comentarioId);
        }

        public async Task DeleteComment(int comentarioId)
        {
            await _comentarioRepository.Delete(comentarioId);
        }

        public async Task<IList<Comentario>> FindComment(string text)
        {
            return await _comentarioRepository.Find(x => x.Texto.Contains(text));
        }

        public async Task<IList<Comentario>> GetComments(int pageNumber, int pageSize)
        {
            return await _comentarioRepository.GetByPage(pageNumber, pageSize);
        }
    }
}
