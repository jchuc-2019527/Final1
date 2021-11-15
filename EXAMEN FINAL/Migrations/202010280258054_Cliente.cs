namespace ProyectoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        CodigoCliente = c.Int(nullable: false, identity: true),
                        NombresCliente = c.String(nullable: false, maxLength: 50, unicode: false),
                        ApellidosCliente = c.String(nullable: false, maxLength: 50, unicode: false),
                        NIT = c.String(nullable: false, maxLength: 9, unicode: false),
                        DireccionCliente = c.String(nullable: false, maxLength: 150, unicode: false),
                        CategoriaCliente = c.String(nullable: false, maxLength: 25, unicode: false),
                        EstadoCliente = c.String(nullable: false, maxLength: 1, unicode: false),
                    })
                .PrimaryKey(t => t.CodigoCliente)
                .Index(t => t.NombresCliente, unique: true, name: "INDEX_NOMBRE_CLIENTE")
                .Index(t => t.ApellidosCliente, unique: true, name: "INDEX_APELLIDO_CLIENTE")
                .Index(t => t.NIT, unique: true, name: "INDEX_NIT")
                .Index(t => t.NIT, unique: true, name: "INDEX_NIT_CLIENTE");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clientes", "INDEX_NIT_CLIENTE");
            DropIndex("dbo.Clientes", "INDEX_NIT");
            DropIndex("dbo.Clientes", "INDEX_APELLIDO_CLIENTE");
            DropIndex("dbo.Clientes", "INDEX_NOMBRE_CLIENTE");
            DropTable("dbo.Clientes");
        }
    }
}
