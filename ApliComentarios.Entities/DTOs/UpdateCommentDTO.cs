using ApiComentarios.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiComentarios.Entities.DTOs
{
    public class UpdateCommentDTO : IRegister
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateCommentDTO, Comments>()
                .Map(d => d.Text, s => s.Texto)
                .Map(d => d.Title, s => s.Titulo);
        }
    }
}
