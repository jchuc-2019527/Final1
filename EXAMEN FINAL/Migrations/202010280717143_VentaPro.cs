namespace ProyectoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VentaPro : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Ventas", "CodigoCliente");
            CreateIndex("dbo.Ventas", "CodigoProducto");
            AddForeignKey("dbo.Ventas", "CodigoCliente", "dbo.Clientes", "CodigoCliente", cascadeDelete: true);
            AddForeignKey("dbo.Ventas", "CodigoProducto", "dbo.Productos", "CodigoProducto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "CodigoProducto", "dbo.Productos");
            DropForeignKey("dbo.Ventas", "CodigoCliente", "dbo.Clientes");
            DropIndex("dbo.Ventas", new[] { "CodigoProducto" });
            DropIndex("dbo.Ventas", new[] { "CodigoCliente" });
        }
    }
}
