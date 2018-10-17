using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lot.Data.Models;
using Lot.Service;


namespace Lot.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosApiController : ControllerBase
    {
        private readonly IEventosService _ieventosService;

        public EventosApiController(IEventosService ieventosService)
        {
            _ieventosService = ieventosService;
        }

        // GET: api/Eventos
        [HttpGet("abiertos")]
        public IEnumerable<Evento> GetEventos()
        {


            return _ieventosService.GetAllEventosOpen().Where(x => x.Cerrado == false); ;
        }

        [HttpGet("cerrados")]
        public IEnumerable<Evento> GetEventosCerrados()
        {


            return _ieventosService.GetAllEventosClose().Where(x => x.Cerrado == true);
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public IActionResult GetEventos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventos = _ieventosService.GetEventos(id);

            if (eventos == null)
            {
                return NotFound();
            }

            return Ok(eventos);
        }

       

        
    }
}