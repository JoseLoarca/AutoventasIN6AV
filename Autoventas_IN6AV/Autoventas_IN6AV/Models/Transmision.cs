using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Transmision
    {
        [Key]
        public int idTransmision { get; set; }
        [Display(Name="Transmisión"), Required(ErrorMessage="Este dato es obligatorio.")]
        public String nombre { get; set; }

        public virtual List<Automovil> automoviles { get; set; }
    }
}