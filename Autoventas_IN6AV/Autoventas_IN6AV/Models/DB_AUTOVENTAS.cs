using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Autoventas_IN6AV.Models
{
    public partial class DB_AUTOVENTAS:DbContext
    {
        public DB_AUTOVENTAS() : base("name=DB_Autoventas") { }
        public virtual DbSet<Archivo> archivo {get; set;}
        public virtual DbSet<Automovil> automovil {get; set;}
        public virtual DbSet<Categoria> categoria {get; set;}
        public virtual DbSet<Combustible> combustible {get; set;}
        public virtual DbSet<Estado> estado {get; set;}
        public virtual DbSet<FormaPago> formaPago {get; set;}
        public virtual DbSet<Marca> marca {get; set;}
        public virtual DbSet<Reservacion> reservacion {get; set;}
        public virtual DbSet<Rol> rol {get; set;}
        public virtual DbSet<Usuario> usuario {get; set;}
        public virtual DbSet<Venta> venta {get; set;}
    }
}