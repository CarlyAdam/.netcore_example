using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lot.Data.Models
{
    public  class Tarjeta:BaseEntity
    {

        public int Numero { get; set; }
        public int EventoId { get; set; }
        public bool Reservada { get; set; }
        public virtual Evento Evento { get; set; }


    }
}
