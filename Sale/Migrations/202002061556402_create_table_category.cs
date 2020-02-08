namespace Sale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            AddColumn("dbo.Productos", "img", c => c.String());
            AlterColumn("dbo.Productos", "precioCosto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Productos", "precioVenta", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Productos", "idCategoria");
            AddForeignKey("dbo.Productos", "idCategoria", "dbo.Categorias", "idCategoria", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "idCategoria", "dbo.Categorias");
            DropIndex("dbo.Productos", new[] { "idCategoria" });
            AlterColumn("dbo.Productos", "precioVenta", c => c.Double(nullable: false));
            AlterColumn("dbo.Productos", "precioCosto", c => c.Double(nullable: false));
            DropColumn("dbo.Productos", "img");
            DropTable("dbo.Categorias");
        }
    }
}
