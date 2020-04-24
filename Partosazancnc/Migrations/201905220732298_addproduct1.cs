namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addproduct1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductType_ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductType_ProductTypeId" });
            RenameColumn(table: "dbo.Products", name: "ProductType_ProductTypeId", newName: "ProductTypeId");
            AlterColumn("dbo.Products", "ProductTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProductTypeId");
            AddForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes", "ProductTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeId", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeId" });
            AlterColumn("dbo.Products", "ProductTypeId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "ProductTypeId", newName: "ProductType_ProductTypeId");
            CreateIndex("dbo.Products", "ProductType_ProductTypeId");
            AddForeignKey("dbo.Products", "ProductType_ProductTypeId", "dbo.ProductTypes", "ProductTypeId");
        }
    }
}
