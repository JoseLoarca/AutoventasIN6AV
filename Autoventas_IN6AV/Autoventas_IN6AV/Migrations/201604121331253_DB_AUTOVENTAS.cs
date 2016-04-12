namespace Autoventas_IN6AV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AUTOVENTAS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Automovils", "reservacion_idReservacion", "dbo.Reservacions");
            DropForeignKey("dbo.Usuarios", "reservacion_idReservacion", "dbo.Reservacions");
            DropIndex("dbo.Automovils", new[] { "reservacion_idReservacion" });
            DropIndex("dbo.Usuarios", new[] { "reservacion_idReservacion" });
            AddColumn("dbo.Reservacions", "idUsuario", c => c.Int(nullable: false));
            AddColumn("dbo.Reservacions", "idAutomovil", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservacions", "idUsuario");
            CreateIndex("dbo.Reservacions", "idAutomovil");
            AddForeignKey("dbo.Reservacions", "idAutomovil", "dbo.Automovils", "idAutomovil", cascadeDelete: true);
            AddForeignKey("dbo.Reservacions", "idUsuario", "dbo.Usuarios", "idUsuario", cascadeDelete: true);
            DropColumn("dbo.Automovils", "reservacion_idReservacion");
            DropColumn("dbo.Usuarios", "reservacion_idReservacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "reservacion_idReservacion", c => c.Int());
            AddColumn("dbo.Automovils", "reservacion_idReservacion", c => c.Int());
            DropForeignKey("dbo.Reservacions", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Reservacions", "idAutomovil", "dbo.Automovils");
            DropIndex("dbo.Reservacions", new[] { "idAutomovil" });
            DropIndex("dbo.Reservacions", new[] { "idUsuario" });
            DropColumn("dbo.Reservacions", "idAutomovil");
            DropColumn("dbo.Reservacions", "idUsuario");
            CreateIndex("dbo.Usuarios", "reservacion_idReservacion");
            CreateIndex("dbo.Automovils", "reservacion_idReservacion");
            AddForeignKey("dbo.Usuarios", "reservacion_idReservacion", "dbo.Reservacions", "idReservacion");
            AddForeignKey("dbo.Automovils", "reservacion_idReservacion", "dbo.Reservacions", "idReservacion");
        }
    }
}
