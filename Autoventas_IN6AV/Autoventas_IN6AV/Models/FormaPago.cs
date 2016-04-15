using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class FormaPago
    {
        [Key]
        public int idFormaPago { get; set; }
        [Display(Name = "Forma de Pago"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String nombre { get; set; }

        public List<Venta> ventas { get; set; }
    }
}