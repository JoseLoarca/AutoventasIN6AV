namespace Autoventas_IN6AV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AUTOVENTAS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        idArchivo = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        ContentType = c.String(),
                        tipo = c.Int(nullable: false),
                        contenido = c.Binary(),
                        automovil_idAutomovil = c.Int(),
                    })
                .PrimaryKey(t => t.idArchivo)
                .ForeignKey("dbo.Automovils", t => t.automovil_idAutomovil)
                .Index(t => t.automovil_idAutomovil);
            
            CreateTable(
                "dbo.Automovils",
                c => new
                    {
                        idAutomovil = c.Int(nullable: false, identity: true),
                        modelo = c.String(nullable: false),
                        año = c.DateTime(nullable: false),
                        color = c.String(nullable: false),
                        precio = c.String(nullable: false),
                        informacionExtra = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idAutomovil);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        automovil_idAutomovil = c.Int(),
                    })
                .PrimaryKey(t => t.idCategoria)
                .ForeignKey("dbo.Automovils", t => t.automovil_idAutomovil)
                .Index(t => t.automovil_idAutomovil);
            
            CreateTable(
                "dbo.Combustibles",
                c => new
                    {
                        idCombustible = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        automovil_idAutomovil = c.Int(),
                    })
                .PrimaryKey(t => t.idCombustible)
                .ForeignKey("dbo.Automovils", t => t.automovil_idAutomovil)
                .Index(t => t.automovil_idAutomovil);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        idEstado = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        automovil_idAutomovil = c.Int(),
                    })
                .PrimaryKey(t => t.idEstado)
                .ForeignKey("dbo.Automovils", t => t.automovil_idAutomovil)
                .Index(t => t.automovil_idAutomovil);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        idMarca = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        automovil_idAutomovil = c.Int(),
                    })
                .PrimaryKey(t => t.idMarca)
                .ForeignKey("dbo.Automovils", t => t.automovil_idAutomovil)
                .Index(t => t.automovil_idAutomovil);
            
            CreateTable(
                "dbo.Reservacions",
                c => new
                    {
                        idReservacion = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        automovil_idAutomovil = c.Int(),
                        usuario_idUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.idReservacion)
                .ForeignKey("dbo.Automovils", t => t.automovil_idAutomovil)
                .ForeignKey("dbo.Usuarios", t => t.usuario_idUsuario)
                .Index(t => t.automovil_idAutomovil)
                .Index(t => t.usuario_idUsuario);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        telefono = c.String(nullable: false, maxLength: 8),
                        correo = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        username = c.String(nullable: false),
                        password = c.String(nullable: false),
                        confirmPassword = c.String(nullable: false),
                        rol_idRol = c.Int(),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Rols", t => t.rol_idRol)
                .Index(t => t.rol_idRol);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idRol);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        idVenta = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        formaPago_idFormaPago = c.Int(),
                        reservacion_idReservacion = c.Int(),
                    })
                .PrimaryKey(t => t.idVenta)
                .ForeignKey("dbo.FormaPagoes", t => t.formaPago_idFormaPago)
                .ForeignKey("dbo.Reservacions", t => t.reservacion_idReservacion)
                .Index(t => t.formaPago_idFormaPago)
                .Index(t => t.reservacion_idReservacion);
            
            CreateTable(
                "dbo.FormaPagoes",
                c => new
                    {
                        idFormaPago = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idFormaPago);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "reservacion_idReservacion", "dbo.Reservacions");
            DropForeignKey("dbo.Ventas", "formaPago_idFormaPago", "dbo.FormaPagoes");
            DropForeignKey("dbo.Usuarios", "rol_idRol", "dbo.Rols");
            DropForeignKey("dbo.Reservacions", "usuario_idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Reservacions", "automovil_idAutomovil", "dbo.Automovils");
            DropForeignKey("dbo.Marcas", "automovil_idAutomovil", "dbo.Automovils");
            DropForeignKey("dbo.Estadoes", "automovil_idAutomovil", "dbo.Automovils");
            DropForeignKey("dbo.Combustibles", "automovil_idAutomovil", "dbo.Automovils");
            DropForeignKey("dbo.Categorias", "automovil_idAutomovil", "dbo.Automovils");
            DropForeignKey("dbo.Archivoes", "automovil_idAutomovil", "dbo.Automovils");
            DropIndex("dbo.Ventas", new[] { "reservacion_idReservacion" });
            DropIndex("dbo.Ventas", new[] { "formaPago_idFormaPago" });
            DropIndex("dbo.Usuarios", new[] { "rol_idRol" });
            DropIndex("dbo.Reservacions", new[] { "usuario_idUsuario" });
            DropIndex("dbo.Reservacions", new[] { "automovil_idAutomovil" });
            DropIndex("dbo.Marcas", new[] { "automovil_idAutomovil" });
            DropIndex("dbo.Estadoes", new[] { "automovil_idAutomovil" });
            DropIndex("dbo.Combustibles", new[] { "automovil_idAutomovil" });
            DropIndex("dbo.Categorias", new[] { "automovil_idAutomovil" });
            DropIndex("dbo.Archivoes", new[] { "automovil_idAutomovil" });
            DropTable("dbo.FormaPagoes");
            DropTable("dbo.Ventas");
            DropTable("dbo.Rols");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Reservacions");
            DropTable("dbo.Marcas");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Combustibles");
            DropTable("dbo.Categorias");
            DropTable("dbo.Automovils");
            DropTable("dbo.Archivoes");
        }
    }
}
