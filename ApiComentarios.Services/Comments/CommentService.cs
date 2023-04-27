using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.DTOSs;
using ApiComentarios.Models;
using MapsterMapper;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiComentarios.Services
{
    public class CommentServices : ICommentService
    {
        private readonly IRepository<Comments> _commentRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public CommentServices(IRepository<Comments> commentRepository, IRepository<User> userRepository)
        {
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<CommentDTO> SaveComment(CommentDTO commentDTO)
        {
            var comment = new Comments()
            {
                Id = commentDTO.Id,
                Title = commentDTO.Title,
                Text = commentDTO.Text,
                UserId = commentDTO.UserId,
                FechaCreacion = DateTime.UtcNow
            };

            var result = await _commentRepository.Save(comment);

            commentDTO.Id = result.Id;

            return commentDTO;
        }

        public async Task<CommentDTO> GetCommentById(int commentId)
        {
            var comment = await _commentRepository.GetById(commentId);

            var response = new CommentDTO()
            {
                Id = comment.Id,
                Title = comment.Title,
                Text = comment.Text,
                UserId = comment.Id,
                FechaCreacion = DateTime.UtcNow
            };

            return response;
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _commentRepository.GetById(commentId);
            await _commentRepository.Delete(comment.Id);
        }

        public async Task<IList<CommentDTO>> FindComment(string text)
        {
            return _mapper.Map<List<CommentDTO>>(await _commentRepository.SearchList(x => x.Text.Contains(text)));
        }

        public async Task<IList<CommentDTO>> GetComments(int pageNumber, int pageSize)
        {
            var list = await _commentRepository.GetByPage(pageNumber, pageSize);
            return list.Select(x => new CommentDTO
            {
                Id = x.Id,
                UserId = x.UserId,
                Text = x.Text,
                Title = x.Title,
                FechaCreacion = x.FechaCreacion,
            }).ToList();
        }
    }
}
