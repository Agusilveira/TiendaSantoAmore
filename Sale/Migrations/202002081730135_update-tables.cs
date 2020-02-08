namespace Sale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productos", "stock", c => c.Int(nullable: false));
            AlterColumn("dbo.Productos", "stockMin", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "stockMin", c => c.String(nullable: false));
            AlterColumn("dbo.Productos", "stock", c => c.String(nullable: false));
        }
    }
}
