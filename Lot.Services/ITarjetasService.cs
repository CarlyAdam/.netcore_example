using Lot.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lot.Service
{
    public interface ITarjetasService
    {
        Tarjeta GetTarjeta(int id);
        void UpdateTarjeta(Tarjeta tarjeta);
        void InsertTarjeta(Tarjeta tarjeta);


    }
}
