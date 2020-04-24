namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _980320 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            AlterColumn("dbo.Products", "ProductTypeId", c => c.Int());
            CreateIndex("dbo.Products", "ProductTypeId");
            AddForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes", "ProductTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            AlterColumn("dbo.Products", "ProductTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProductTypeId");
            AddForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes", "ProductTypeId", cascadeDelete: true);
        }
    }
}
