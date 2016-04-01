using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Combustible
    {
        [Key]
        public int idCombustible { get; set; }
        [Display(Name = "Combustible"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String nombre { get; set; }

        public virtual List<Automovil> automoviles { get; set; }
    }
}