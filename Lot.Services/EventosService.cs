using Lot.Data.Models;
using Lot.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Lot.Service
{
    public class EventosService : IEventosService
    {
        private IRepository<Evento> eventosRepository;

        public EventosService(IRepository<Evento> eventosRepository)
        {
            this.eventosRepository = eventosRepository;
        }

        public List<Evento> GetAllEventosOpen()
        {

            return eventosRepository.GetQueryable().Include(c => c.Tarjeta).ToList();
        }

        public List<Evento> GetAllEventosClose()
        {

            return eventosRepository.GetQueryable().Include(c => c.Tarjeta).ToList();
        }


        public Evento GetEventos(int id)
        {
            return eventosRepository.Get(id);
        }

        public void InsertEventos(Evento evento)
        {
            eventosRepository.Insert(evento);
            
        }
        public void UpdateEventos(Evento evento)
        {
            eventosRepository.Update(evento);
        }

        public void DeleteEventos(int id)
        {
            Evento evento = GetEventos(id);
            eventosRepository.Remove(evento);
            eventosRepository.SaveChanges();
        }
    }
}
