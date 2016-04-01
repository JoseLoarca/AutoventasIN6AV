using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
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

        
        public int? idArchivo { get; set; }
        public virtual Archivo archivo { get; set; }

        public int idMarca { get; set; }
        public virtual Marca marca { get; set; }

        public int idCategoria { get; set; }
        public virtual Categoria categoria { get; set; }

        public int idCombustible { get; set; }
        public virtual Combustible combustible { get; set; }

        public int idEstado { get; set; }
        public virtual Estado estado { get; set; }

        public int idTransmision { get; set; }
        public virtual Transmision transmision { get; set; }

        public virtual Reservacion reservacion { get; set; }
        
    }
}