namespace Sale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crear_tabla_productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        idProducto = c.Int(nullable: false, identity: true),
                        codigo = c.String(nullable: false),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(nullable: false),
                        stock = c.String(nullable: false),
                        stockMin = c.String(nullable: false),
                        precioCosto = c.Double(nullable: false),
                        precioVenta = c.Double(nullable: false),
                        idCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idProducto);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productos");
        }
    }
}
