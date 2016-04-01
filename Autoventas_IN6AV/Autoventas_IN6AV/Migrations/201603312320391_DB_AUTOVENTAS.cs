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
                    })
                .PrimaryKey(t => t.idArchivo);
            
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
                        idArchivo = c.Int(),
                        idMarca = c.Int(nullable: false),
                        idCategoria = c.Int(nullable: false),
                        idCombustible = c.Int(nullable: false),
                        idEstado = c.Int(nullable: false),
                        idTransmision = c.Int(nullable: false),
                        reservacion_idReservacion = c.Int(),
                    })
                .PrimaryKey(t => t.idAutomovil)
                .ForeignKey("dbo.Archivoes", t => t.idArchivo)
                .ForeignKey("dbo.Categorias", t => t.idCategoria, cascadeDelete: true)
                .ForeignKey("dbo.Combustibles", t => t.idCombustible, cascadeDelete: true)
                .ForeignKey("dbo.Estadoes", t => t.idEstado, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.idMarca, cascadeDelete: true)
                .ForeignKey("dbo.Reservacions", t => t.reservacion_idReservacion)
                .ForeignKey("dbo.Transmisions", t => t.idTransmision, cascadeDelete: true)
                .Index(t => t.idArchivo)
                .Index(t => t.idMarca)
                .Index(t => t.idCategoria)
                .Index(t => t.idCombustible)
                .Index(t => t.idEstado)
                .Index(t => t.idTransmision)
                .Index(t => t.reservacion_idReservacion);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            CreateTable(
                "dbo.Combustibles",
                c => new
                    {
                        idCombustible = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idCombustible);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        idEstado = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idEstado);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        idMarca = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idMarca);
            
            CreateTable(
                "dbo.Reservacions",
                c => new
                    {
                        idReservacion = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idReservacion);
            
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
                        reservacion_idReservacion = c.Int(),
                        rol_idRol = c.Int(),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Reservacions", t => t.reservacion_idReservacion)
                .ForeignKey("dbo.Rols", t => t.rol_idRol)
                .Index(t => t.reservacion_idReservacion)
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
                        idReservacion = c.Int(nullable: false),
                        idFormaPago = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVenta)
                .ForeignKey("dbo.FormaPagoes", t => t.idFormaPago, cascadeDelete: true)
                .ForeignKey("dbo.Reservacions", t => t.idReservacion, cascadeDelete: true)
                .Index(t => t.idReservacion)
                .Index(t => t.idFormaPago);
            
            CreateTable(
                "dbo.FormaPagoes",
                c => new
                    {
                        idFormaPago = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idFormaPago);
            
            CreateTable(
                "dbo.Transmisions",
                c => new
                    {
                        idTransmision = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idTransmision);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Automovils", "idTransmision", "dbo.Transmisions");
            DropForeignKey("dbo.Ventas", "idReservacion", "dbo.Reservacions");
            DropForeignKey("dbo.Ventas", "idFormaPago", "dbo.FormaPagoes");
            DropForeignKey("dbo.Usuarios", "rol_idRol", "dbo.Rols");
            DropForeignKey("dbo.Usuarios", "reservacion_idReservacion", "dbo.Reservacions");
            DropForeignKey("dbo.Automovils", "reservacion_idReservacion", "dbo.Reservacions");
            DropForeignKey("dbo.Automovils", "idMarca", "dbo.Marcas");
            DropForeignKey("dbo.Automovils", "idEstado", "dbo.Estadoes");
            DropForeignKey("dbo.Automovils", "idCombustible", "dbo.Combustibles");
            DropForeignKey("dbo.Automovils", "idCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Automovils", "idArchivo", "dbo.Archivoes");
            DropIndex("dbo.Ventas", new[] { "idFormaPago" });
            DropIndex("dbo.Ventas", new[] { "idReservacion" });
            DropIndex("dbo.Usuarios", new[] { "rol_idRol" });
            DropIndex("dbo.Usuarios", new[] { "reservacion_idReservacion" });
            DropIndex("dbo.Automovils", new[] { "reservacion_idReservacion" });
            DropIndex("dbo.Automovils", new[] { "idTransmision" });
            DropIndex("dbo.Automovils", new[] { "idEstado" });
            DropIndex("dbo.Automovils", new[] { "idCombustible" });
            DropIndex("dbo.Automovils", new[] { "idCategoria" });
            DropIndex("dbo.Automovils", new[] { "idMarca" });
            DropIndex("dbo.Automovils", new[] { "idArchivo" });
            DropTable("dbo.Transmisions");
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
