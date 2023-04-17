using ApiComentarios.DTOSs;
using ApiComentarios.Entities.DTOs;
using ApiComentarios.Models;
using AutoMapper;
using Models;

namespace ApiComentarios.WebApi.Profiles
{
    public class ComentariosProfile : Profile
    {
        public ComentariosProfile()
        {
            CreateMap<Comments, CommentDTO>()
            .ReverseMap();

            CreateMap<User, UserInfoDTO>()
            .ReverseMap();
        }
    }
}
