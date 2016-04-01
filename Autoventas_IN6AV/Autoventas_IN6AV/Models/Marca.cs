using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Marca
    {
        [Key]
        public int idMarca { get; set; }
        [Display(Name = "Marca"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String nombre { get; set; }

        public virtual List<Automovil> automoviles { get; set; }
    }
}