using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services
{
    public class CommentServices : ICommentService
    {
        private readonly IRepository<Comments> _commentRepository;

        public CommentServices(IRepository<Comments> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comments> SaveComment(Comments comment)
        {
            comment.FechaCreacion = DateTime.UtcNow;
            return (Comments)await _commentRepository.Save(comment);
        }

        public async Task<Comments> GetCommentById(int commentId)
        {
            return await _commentRepository.GetById(commentId);
        }

        public async Task DeleteComment(int commentId)
        {
            await _commentRepository.Delete(commentId);
        }

        public async Task<IList<Comments>> FindComment(string text)
        {
            return await _commentRepository.SearchList(x => x.Texto.Contains(text));
        }

        public async Task<IList<Comments>> GetComments(int pageNumber, int pageSize)
        {
            return await _commentRepository.GetByPage(pageNumber, pageSize);
        }
    }
}
