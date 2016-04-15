using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        [Display(Name = "Categoria"), Required(ErrorMessage = "Este tipo de dato es obligatorio.")]
        public String nombre { get; set; }

        public virtual List<Automovil> automoviles { get; set; }
    }
}