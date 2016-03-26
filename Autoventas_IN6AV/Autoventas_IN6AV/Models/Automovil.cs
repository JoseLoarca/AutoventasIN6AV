using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Automovil
    {
        [Key]
        public int idAutomovil { get; set; }
        [Display(Name = "Modelo"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String modelo { get; set; }
        [Display(Name = "Año de Fabricación"), Required(ErrorMessage = "Este dato es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime año { get; set; }
        [Display(Name = "Color"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String color { get; set; }
        [Display(Name = "Precio"), Required(ErrorMessage = "Este dato es obligatorio."), DataType(DataType.Currency)]
        public String precio { get; set; }
        [Display(Name = "Extras"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String informacionExtra { get; set; }

        public virtual List<Archivo> archivos { get; set; }
        public virtual List<Marca> marcas { get; set; }
        public virtual List<Categoria> categorias { get; set; }
        public virtual List<Combustible> combustibles { get; set; }
        public virtual List<Estado> estados { get; set; }
        public virtual List<Reservacion> reservaciones { get; set; }
    }
}