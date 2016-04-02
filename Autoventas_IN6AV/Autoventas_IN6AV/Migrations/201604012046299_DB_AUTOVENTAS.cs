namespace Autoventas_IN6AV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_AUTOVENTAS : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Automovils", "idArchivo", "dbo.Archivoes");
            DropIndex("dbo.Automovils", new[] { "idArchivo" });
            AddColumn("dbo.Archivoes", "idAutomovil", c => c.Int(nullable: false));
            CreateIndex("dbo.Archivoes", "idAutomovil");
            AddForeignKey("dbo.Archivoes", "idAutomovil", "dbo.Automovils", "idAutomovil", cascadeDelete: true);
            DropColumn("dbo.Automovils", "idArchivo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Automovils", "idArchivo", c => c.Int());
            DropForeignKey("dbo.Archivoes", "idAutomovil", "dbo.Automovils");
            DropIndex("dbo.Archivoes", new[] { "idAutomovil" });
            DropColumn("dbo.Archivoes", "idAutomovil");
            CreateIndex("dbo.Automovils", "idArchivo");
            AddForeignKey("dbo.Automovils", "idArchivo", "dbo.Archivoes", "idArchivo");
        }
    }
}
