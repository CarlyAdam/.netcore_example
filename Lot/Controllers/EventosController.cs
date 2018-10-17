using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lot.Data.Models;
using Lot.Repo;
using Lot.Service;
using Lot.Web.Models;

namespace Lot.Web.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventosService _ieventosService;
        private readonly ITarjetasService _itarjetasService;

        public EventosController(IEventosService ieventosService, ITarjetasService itarjetasService)
        {
            _ieventosService = ieventosService;
            _itarjetasService = itarjetasService;
        }

        // GET: Eventos
        public  IActionResult Index()
        {
            List<EventoViewModel> model = new List<EventoViewModel>();


            _ieventosService.GetAllEventosOpen().ForEach(u =>
            {
                EventoViewModel evento = new EventoViewModel
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Descripcion = u.Descripcion,
                    Fechainicio = u.Fechainicio,
                    Fechafin = u.Fechafin,
                    TarjetaWin = u.TarjetaWin,
                    Cerrado = u.Cerrado
                };
                model.Add(evento);
            });

            return View(model);
        }


        // GET: Eventos/Create
        public IActionResult Create()
        {
            EventoViewModel evento = new EventoViewModel();
            return View();
        }

       
       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EventoViewModel evento)
        {
            Evento eventoEntity = new Evento
            {
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                Fechainicio = evento.Fechainicio,
                Fechafin = evento.Fechafin
            };
            if (eventoEntity.Fechainicio >= eventoEntity.Fechafin)
            {
                ModelState.AddModelError("Error"," StartTime can not be higher than EndTime");
            }
            else
            {
                _ieventosService.InsertEventos(eventoEntity);
                List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                foreach (int numero in numeros)
                {
                    Tarjeta tarjeta = new Tarjeta();
                    tarjeta.Numero = numero;
                    tarjeta.EventoId = eventoEntity.Id;
                    _itarjetasService.InsertTarjeta(tarjeta);


                }
            }

                if (eventoEntity.Id > 0)
                {
                    return RedirectToAction("index");
                }

                return View(evento);
            
        }


        // GET: Eventos1/Edit/5
        public IActionResult Edit(int? id)
        {
            EventoViewModel evento = new EventoViewModel();
            if (id.HasValue && id != 0)
            {
                Evento eventoEntity = _ieventosService.GetEventos(id.Value);
                evento.Nombre = eventoEntity.Nombre;
                evento.Descripcion = eventoEntity.Descripcion;
                evento.Fechainicio = eventoEntity.Fechainicio;
                evento.Fechafin = eventoEntity.Fechainicio;
            }
            return View(evento);
        }

        // POST: Eventos1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Edit( EventoViewModel evento)
        {

            Evento eventoEntity = _ieventosService.GetEventos(evento.Id);
            eventoEntity.Nombre = evento.Nombre;
            eventoEntity.Descripcion = evento.Descripcion;
            eventoEntity.Fechainicio = evento.Fechainicio;
            eventoEntity.Fechafin = evento.Fechafin;
            _ieventosService.UpdateEventos(eventoEntity);
            if (eventoEntity.Id > 0)
            {
                return RedirectToAction("index");
            }
            return View(evento);
        }

      

        // GET: Eventos/Delete/5
        public IActionResult Delete(int? id)
        {
            
            //

            
            if (id == null)
            {
                return NotFound();
            }
            EventoViewModel evento = new EventoViewModel();
           

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ieventosService.DeleteEventos(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
