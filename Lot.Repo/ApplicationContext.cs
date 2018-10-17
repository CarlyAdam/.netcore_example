using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Lot.Data.Models;


namespace Lot.Repo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Tarjeta> Tarjeta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new EventoMap(modelBuilder.Entity<Evento>());
            new TarjetaMap(modelBuilder.Entity<Tarjeta>());
        }

    }
}
