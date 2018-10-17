using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Lot.Data.Models;

namespace Lot.Data.Models
{
    public class TarjetaMap
    {
        public TarjetaMap(EntityTypeBuilder<Tarjeta> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Numero);
            entityBuilder.Property(t => t.EventoId);
            entityBuilder.Property(t => t.Reservada);
            entityBuilder.HasOne(
               t => t.Evento)
               .WithMany(u => u.Tarjeta)
               .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

        }

    }
    }

