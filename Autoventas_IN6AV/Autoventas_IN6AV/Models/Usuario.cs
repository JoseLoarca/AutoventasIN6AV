using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Autoventas_IN6AV.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        [Display(Name = "Nombre"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String nombre { get; set; }
        [Display(Name = "Telefono"), Required(ErrorMessage = "Este dato es obligatorio."), DataType(DataType.PhoneNumber)]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El número de tel. tiene que tener 8 digitos.")]
        public String telefono { get; set; }
        [Display(Name = "Correo Electrónico"), Required(ErrorMessage = "Este dato es obligatorio.")] 
        [DataType(DataType.EmailAddress, ErrorMessage="Por favor ingrese una dirección de correo válida.")]
        public String correo { get; set; }
        [Display(Name = "Dirección"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String direccion { get; set; }
        [Display(Name = "Nombre de Usuario"), Required(ErrorMessage = "Este dato es obligatorio.")]
        public String username { get; set; }
        [Display(Name = "Contraseña"), Required(ErrorMessage = "Este dato es obligatorio."), DataType(DataType.Password)]
        public String password { get; set; }
        [Display(Name = "Confirmar Contraseña"), Required(ErrorMessage = "Este dato es obligatorio."), DataType(DataType.Password)]
        [Compare("password", ErrorMessage="Las contraseñas no coinciden.")]
        public String confirmPassword { get; set; }

        public virtual Rol rol { get; set; }
        public virtual Reservacion reservacion { get; set; }
    }
}