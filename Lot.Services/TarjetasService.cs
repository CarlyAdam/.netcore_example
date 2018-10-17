using Lot.Data.Models;
using Lot.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Lot.Service
{
    public class TarjetasService : ITarjetasService
    {
        private IRepository<Tarjeta> tarjetasRepository;

        public TarjetasService(IRepository<Tarjeta> tarjetasRepository)
        {
            this.tarjetasRepository = tarjetasRepository;
        }

        public void UpdateTarjeta(Tarjeta tarjeta)
        {
            tarjetasRepository.Update(tarjeta);
        }

        public void InsertTarjeta(Tarjeta tarjeta)
        {
            tarjetasRepository.Insert(tarjeta);

        }

        public Tarjeta GetTarjeta(int id)
        {
            return tarjetasRepository.Get(id);
        }

    }
}
