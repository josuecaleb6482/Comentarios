using ApiComentarios.DTOSs;
using ApiComentarios.Models;
using AutoMapper;

namespace ApiComentarios.WebApi.Profiles
{
    public class ComentariosProfile : Profile
    {
        public ComentariosProfile()
        {
            CreateMap<Comentario,ComentarioDTO>();
        }
    }
}
