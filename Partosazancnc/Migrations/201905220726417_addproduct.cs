namespace Partosazancnc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductAttachFiles",
                c => new
                    {
                        ProductAttachFileID = c.Int(nullable: false, identity: true),
                        AttachFileTitle = c.String(maxLength: 300),
                        FileName = c.String(nullable: false, maxLength: 700),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductAttachFileID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        ShortDiscription = c.String(nullable: false, maxLength: 350),
                        Text = c.String(),
                        PicThumbnail = c.String(maxLength: 350),
                        KeyWord = c.String(maxLength: 500),
                        Date = c.DateTime(nullable: false),
                        ProductType_ProductTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductType_ProductTypeId)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ProductType_ProductTypeId);
            
            CreateTable(
                "dbo.ProductGalleries",
                c => new
                    {
                        ProductGalleryID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 350),
                        Title = c.String(nullable: false, maxLength: 150),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductGalleryID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductProperties",
                c => new
                    {
                        ProductPropertyID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        PropertyTitle = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPropertyID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        image = c.String(maxLength: 150),
                        Discription = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.ProductTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UserID", "dbo.Users");
            DropForeignKey("dbo.Products", "ProductType_ProductTypeId", "dbo.ProductTypes");
            DropForeignKey("dbo.ProductProperties", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductGalleries", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductAttachFiles", "ProductID", "dbo.Products");
            DropIndex("dbo.ProductProperties", new[] { "ProductID" });
            DropIndex("dbo.ProductGalleries", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "ProductType_ProductTypeId" });
            DropIndex("dbo.Products", new[] { "UserID" });
            DropIndex("dbo.ProductAttachFiles", new[] { "ProductID" });
            DropTable("dbo.ProductTypes");
            DropTable("dbo.ProductProperties");
            DropTable("dbo.ProductGalleries");
            DropTable("dbo.Products");
            DropTable("dbo.ProductAttachFiles");
        }
    }
}
