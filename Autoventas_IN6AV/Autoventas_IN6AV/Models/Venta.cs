using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Venta
    {
        [Key]
        public int idVenta { get; set; }
        [Display(Name = "Fecha de Venta"), Required(ErrorMessage = "Este dato es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha { get; set; }

        public int idReservacion { get; set; }
        public virtual Reservacion reservacion { get; set; }

        public int idFormaPago { get; set; }
        public virtual FormaPago formaPago { get; set; }
    }
}