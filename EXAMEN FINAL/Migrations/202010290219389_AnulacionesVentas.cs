namespace ProyectoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnulacionesVentas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnulacionVentas",
                c => new
                    {
                        CodigoAnulacion = c.Int(nullable: false, identity: true),
                        CodigoVenta = c.Int(nullable: false),
                        FechaDevo = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.CodigoAnulacion);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AnulacionVentas");
        }
    }
}
