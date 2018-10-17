using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lot.Data.Models;

namespace Lot.Data.Models
{
    public class EventoMap
    {
        public EventoMap(EntityTypeBuilder<Evento> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Nombre);
            entityBuilder.Property(t => t.Descripcion);
            entityBuilder.Property(t => t.TarjetaWin);
            entityBuilder.Property(t => t.Fechainicio);
            entityBuilder.Property(t => t.Fechafin);
            entityBuilder.Property(t => t.Cerrado);
            entityBuilder.HasMany(
                t => t.Tarjeta)
                .WithOne(u => u.Evento);

        }
    }
}
