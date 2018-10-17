using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lot.Data.Models
{
    public  class Evento:BaseEntity
    {
        
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TarjetaWin { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafin { get; set; }
        public bool Cerrado { get; set; }
        public virtual ICollection<Tarjeta> Tarjeta { get; set; }

    }
}
