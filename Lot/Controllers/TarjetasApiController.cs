using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lot.Data.Models;
using Lot.Repo;
using Lot.Service;

namespace Lot.Web.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetasApiController : ControllerBase
    {
        private readonly ITarjetasService _itarjetasService;

        public TarjetasApiController(ITarjetasService itarjetasService)
        {
            _itarjetasService = itarjetasService;
        }

        // PUT: api/Tarjetas/5
      [HttpPut("{id}")]
        public IActionResult Update(int id, Tarjeta tarjeta)
        {
            var tarjeta_id = _itarjetasService.GetTarjeta(id);

            if (tarjeta == null )
            {
                return NotFound();
            }

            tarjeta_id.Id = tarjeta.Id;
            tarjeta_id.Numero = tarjeta.Numero;
            tarjeta_id.Reservada = tarjeta.Reservada;



            _itarjetasService.UpdateTarjeta(tarjeta_id);
           
            return Ok();
        }


    }
}