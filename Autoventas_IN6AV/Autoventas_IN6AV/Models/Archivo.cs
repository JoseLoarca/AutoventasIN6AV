using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autoventas_IN6AV.Models
{
    public class Archivo
    {
        [Key]
        public int idArchivo { get; set; }
        public String nombre { get; set; }
        public String ContentType { get; set; }
        public FileType tipo { get; set; }
        public Byte[] contenido { get; set; }

        public int idAutomovil { get; set; }
        public virtual Automovil automovil { get; set; }
    }
}