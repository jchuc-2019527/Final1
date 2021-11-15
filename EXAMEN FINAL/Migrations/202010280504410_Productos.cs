namespace ProyectoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        CodigoProducto = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        CodigoProveedor = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false, storeType: "date"),
                        UbicacionFisica = c.String(nullable: false, maxLength: 150, unicode: false),
                        ExistenciaMinima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoProducto)
                .Index(t => t.Descripcion, unique: true, name: "INDEX_DESCRIPCION");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Productos", "INDEX_DESCRIPCION");
            DropTable("dbo.Productos");
        }
    }
}
