using ApiComentarios.Abtractions.Interfaces;
using ApiComentarios.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiComentarios.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyBaseController<TEntity, TService> : ControllerBase
        where TEntity : class, IEntity
    {
        public readonly TService _service;
        public MyBaseController(TService service)
        {
            _service = service;
        }

        protected int MaxItemsPage { get; set; } = 10;

        protected int MaxSizePage { get; set; } = 100;

        protected void ConfigurarPaginacion(PaginacionDTO paginacionDTO)
        {
            paginacionDTO.maxItemsPage = Math.Min(paginacionDTO.maxItemsPage, MaxSizePage);
            paginacionDTO.maxItemsPage = Math.Max(1, paginacionDTO.maxItemsPage);
        }

    }
}

