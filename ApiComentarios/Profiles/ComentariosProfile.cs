using ApiComentarios.DTOSs;
using ApiComentarios.Models;
using AutoMapper;
using Models;

namespace ApiComentarios.WebApi.Profiles
{
    public class ComentariosProfile : Profile
    {
        public ComentariosProfile()
        {
            CreateMap<Comments, ComentarioDTO>()
            .ReverseMap();
        }
    }
}
