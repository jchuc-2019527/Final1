namespace ProyectoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ventas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        CodigoVenta = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 200, unicode: false),
                        CodigoCliente = c.Int(nullable: false),
                        CodigoProducto = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        TipoVenta = c.String(nullable: false, maxLength: 5, unicode: false),
                        FechaVenta = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.CodigoVenta);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ventas");
        }
    }
}
