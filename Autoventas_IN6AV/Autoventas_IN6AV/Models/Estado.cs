using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        [Display(Name = "Estado"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String nombre { get; set; }

        public virtual List<Automovil> automoviles { get; set; }
    }
}