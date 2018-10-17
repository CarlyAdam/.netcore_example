using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Lot.Data.Models;

namespace Lot.Web.Models
{
    public class EventoViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Start Time is required")]
        public DateTime Fechainicio { get; set; }
        [Required(ErrorMessage = "End time is required")]
        public DateTime Fechafin { get; set; }
        public string TarjetaWin { get; set; }
        public bool Cerrado { get; set; }

    }
}
