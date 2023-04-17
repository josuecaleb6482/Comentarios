using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.DTOSs;
using ApiComentarios.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiComentarios.Services
{
    public class CommentServices : ICommentService
    {
        private readonly IRepository<Comments> _commentRepository;
        private readonly IMapper _mapper;
        public CommentServices(IRepository<Comments> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comments> SaveComment(CommentDTO commentDTO, int commentId)
        {
            var comment = new Comments();

            if(commentId == 0)
            {
                comment = _mapper.Map<Comments>(commentDTO);
            }
            else
            {
                comment = await _commentRepository.GetById(commentId);
                comment.Titulo = commentDTO.Titulo;
                comment.Texto = commentDTO.Texto;
            }
                       
            comment.FechaCreacion = DateTime.UtcNow;

            return (Comments)await _commentRepository.Save(comment);
        }

        public async Task<CommentDTO> GetCommentById(int commentId)
        {
            var comment = await _commentRepository.GetById(commentId);
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _commentRepository.GetById(commentId);
            await _commentRepository.Delete(comment.Id);
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
