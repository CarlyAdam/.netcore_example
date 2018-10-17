using Lot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lot.Service
{
    public interface IEventosService
    {
        List<Evento> GetAllEventosOpen();
        List<Evento> GetAllEventosClose();
        //List<Evento> GetEventos();
        Evento GetEventos(int id);
        void InsertEventos(Evento evento);
        void UpdateEventos(Evento evento);
        void DeleteEventos(int id);
    }
}
