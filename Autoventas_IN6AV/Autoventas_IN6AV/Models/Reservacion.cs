using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Reservacion
    {
        [Key]
        public int idReservacion { get; set; }
        [Display(Name = "Fecha de Reservación"), Required(ErrorMessage = "Este dato es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        public virtual List<Usuario> usuarios { get; set; }
        public virtual List<Automovil> automoviles { get; set; }
        public virtual List<Venta> ventas { get; set; }
    }
}