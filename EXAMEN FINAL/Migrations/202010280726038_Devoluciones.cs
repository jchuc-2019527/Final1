namespace ProyectoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Devoluciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devoluciones",
                c => new
                    {
                        CodigoDevolucion = c.Int(nullable: false, identity: true),
                        CodigoVenta = c.Int(nullable: false),
                        CantidadDevolver = c.Int(nullable: false),
                        FechaDevolucion = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.CodigoDevolucion)
                .ForeignKey("dbo.Ventas", t => t.CodigoVenta, cascadeDelete: true)
                .Index(t => t.CodigoVenta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devoluciones", "CodigoVenta", "dbo.Ventas");
            DropIndex("dbo.Devoluciones", new[] { "CodigoVenta" });
            DropTable("dbo.Devoluciones");
        }
    }
}
